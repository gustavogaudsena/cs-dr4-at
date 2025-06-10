using DR3_AT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DR3_AT.Data.Configurations;

public class PacoteTuristicoConfiguration: IEntityTypeConfiguration<PacoteTuristico>
{
    public void Configure(EntityTypeBuilder<PacoteTuristico> builder)
    {
        builder.Property(c => c.Titulo)
            .HasMaxLength(100)
            .HasColumnName("Titulo");
        
        builder.HasData(
            new PacoteTuristico
            {
                Id = 1, Titulo = "Férias em Cabo Frio", DataInicio = new DateTime(2025, 6, 15),
                DataFinal = new DateTime(2025, 6, 20) , CapacidadeMaxima = 20, Preco = 150.0m
            },
            new PacoteTuristico
            {
                Id = 2, Titulo = "Passeio em Angra dos Reis", DataInicio = new DateTime(2025, 7, 20),
                DataFinal = new DateTime(2025, 7, 30), CapacidadeMaxima = 10, Preco = 350.0m
            }
        );
    }
    
}