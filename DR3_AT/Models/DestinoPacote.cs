using Microsoft.EntityFrameworkCore;

namespace DR3_AT.Models;

[PrimaryKey("DestinoId", "PacoteId")]
public class DestinoPacote
{
    public int DestinoId { get; set; }
    public Destino Destino { get; set; }
    public int PacoteId { get; set; }
    public PacoteTuristico PacoteTuristico  { get; set; }
}