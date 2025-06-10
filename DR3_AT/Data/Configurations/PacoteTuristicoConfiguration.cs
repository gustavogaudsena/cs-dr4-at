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

        var destinos = new List<Destino>
        {
            new Destino { Id = 1, Nome = "Rio de Janeiro", Pais = "Brasil" },
            new Destino { Id = 2, Nome = "Angra dos Reis", Pais = "Brasil" },
            new Destino { Id = 3, Nome = "Cabo Frio", Pais = "Brasil" }
        };
        
        builder.HasData(
            new PacoteTuristico
            {
                Id = 1, Titulo = "Férias em Cabo Frio", DataInicio = DateTime.Now.AddDays(10),
                DataFinal = DateTime.Now.AddDays(30) , CapacidadeMaxima = 20, Preco = 150.0m
            },
            new PacoteTuristico
            {
                Id = 2, Titulo = "Passeio em Angra dos Reis", DataInicio = DateTime.Now.AddDays(30),
                DataFinal = DateTime.Now.AddDays(35), CapacidadeMaxima = 10, Preco = 350.0m
            }
        );
    }
    
}