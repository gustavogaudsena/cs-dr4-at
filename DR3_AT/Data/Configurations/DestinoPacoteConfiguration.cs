using DR3_AT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DR3_AT.Data.Configurations;

public class DestinoPacoteConfiguration : IEntityTypeConfiguration<DestinoPacote>
{
    public void Configure(EntityTypeBuilder<DestinoPacote> builder)
    {
        builder.HasKey(dp => new { dp.DestinoId, dp.PacoteId });
        
        builder.HasOne(dp => dp.Destino)
               .WithMany(d => d.PacotesDestinos) 
               .HasForeignKey(dp => dp.DestinoId);

        builder.HasOne(dp => dp.PacoteTuristico)
               .WithMany(p => p.DestinosPacotes) 
               .HasForeignKey(dp => dp.PacoteId);
               
        builder.HasData(
            new DestinoPacote { PacoteId = 1, DestinoId = 3 },
            new DestinoPacote { PacoteId = 2, DestinoId = 2 },
            new DestinoPacote { PacoteId = 2, DestinoId = 1 }
        );
    }
}