using DR3_AT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DR3_AT.Data.Configurations;

public class ReservaConfiguration: IEntityTypeConfiguration<Reserva>
{
    public void Configure(EntityTypeBuilder<Reserva> builder)
    {
        var destinos = new List<Destino>
        {
            new Destino { Id = 1, Nome = "Rio de Janeiro", Pais = "Brasil" },
            new Destino { Id = 2, Nome = "Angra dos Reis", Pais = "Brasil" },
            new Destino { Id = 3, Nome = "Cabo Frio", Pais = "Brasil" }
        };
        
        builder.HasData(
            new Reserva
            {
                Id = 1,
                PacoteTuristicoId = 1,
                DataReserva = DateTime.Now,
                ClienteId = 1
            }
        );
    }
    
}