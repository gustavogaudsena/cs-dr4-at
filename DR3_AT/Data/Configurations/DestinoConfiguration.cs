using DR3_AT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DR3_AT.Data.Configurations;

public class DestinoConfiguration: IEntityTypeConfiguration<Destino>
{
    public void Configure(EntityTypeBuilder<Destino> builder)
    {
        builder.Property(c => c.Nome)
            .HasMaxLength(100)
            .HasColumnName("Nome");

        builder.HasData(
            new Destino { Id = 1, Nome = "Rio de Janeiro", Pais = "Brasil" },
            new Destino { Id = 2, Nome = "Angra dos Reis", Pais = "Brasil" },
            new Destino { Id = 3, Nome = "Cabo Frio", Pais = "Brasil" }
        );
    }
    
}