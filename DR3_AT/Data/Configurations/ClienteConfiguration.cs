using DR3_AT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DR3_AT.Data.Configurations;

public class ClienteConfiguration: IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.Property(c => c.Nome)
            .HasMaxLength(100)
            .HasColumnName("Nome");

        builder.HasData(
            new Cliente { Id = 1, Nome = "Gustavo Sena" , Email = "sena@mail.com"}, 
            new Cliente { Id = 2, Nome = "Rinaldo Ferreira" , Email = "rinaldo@mail.com"}
        );
    }
    
}