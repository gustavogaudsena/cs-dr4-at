using DR3_AT.Data.Configurations;
using DR3_AT.Models;

namespace DR3_AT.Data;
using Microsoft.EntityFrameworkCore;

public class AgenciaTurismoContext  : DbContext
{
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Destino> Destinos { get; set; }
    public DbSet<PacoteTuristico> Pacotes { get; set; }
    public DbSet<Reserva> Reservas { get; set; }

    public AgenciaTurismoContext(DbContextOptions<AgenciaTurismoContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ClienteConfiguration());
        modelBuilder.ApplyConfiguration(new DestinoConfiguration());
        modelBuilder.ApplyConfiguration(new PacoteTuristicoConfiguration());
        modelBuilder.ApplyConfiguration(new ReservaConfiguration());
        modelBuilder.ApplyConfiguration(new DestinoPacoteConfiguration());
    }
}
