using System;
using System.Collections.Generic;
using DR3_AT.MigrationsScaffold;
using Microsoft.EntityFrameworkCore;

namespace DR3_AT.Context;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Destino> Destinos { get; set; }

    public virtual DbSet<EfmigrationsLock> EfmigrationsLocks { get; set; }

    public virtual DbSet<Pacote> Pacotes { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=/Users/gustavosena/Documents/Infnet/SEMESTRE 4/DR4/TP2/DR3_AT/DR3_AT/Data/agenciadb.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Destino>(entity =>
        {
            entity.HasMany(d => d.Pacotes).WithMany(p => p.Destinos)
                .UsingEntity<Dictionary<string, object>>(
                    "DestinoPacote",
                    r => r.HasOne<Pacote>().WithMany().HasForeignKey("PacoteId"),
                    l => l.HasOne<Destino>().WithMany().HasForeignKey("DestinoId"),
                    j =>
                    {
                        j.HasKey("DestinoId", "PacoteId");
                        j.ToTable("DestinoPacote");
                        j.HasIndex(new[] { "PacoteId" }, "IX_DestinoPacote_PacoteId");
                    });
        });

        modelBuilder.Entity<EfmigrationsLock>(entity =>
        {
            entity.ToTable("__EFMigrationsLock");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasIndex(e => new { e.ClienteId, e.PacoteTuristicoId }, "IX_Reservas_ClienteId_PacoteTuristicoId").IsUnique();

            entity.HasIndex(e => e.PacoteTuristicoId, "IX_Reservas_PacoteTuristicoId");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Reservas).HasForeignKey(d => d.ClienteId);

            entity.HasOne(d => d.PacoteTuristico).WithMany(p => p.Reservas).HasForeignKey(d => d.PacoteTuristicoId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
