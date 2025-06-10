using DR3_AT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DR3_AT.Data.Configurations;

public class ReservaConfiguration: IEntityTypeConfiguration<Reserva>
{
    public void Configure(EntityTypeBuilder<Reserva> builder)
    {
        
        builder.HasIndex(r => new { r.ClienteId, r.PacoteTuristicoId }).IsUnique();
        
        builder.HasData(
            new Reserva
            {
                Id = 1,
                PacoteTuristicoId = 1,
                DataReserva = new DateTime(2025, 6, 7),
                ClienteId = 1
            }
        );
    }
    
}