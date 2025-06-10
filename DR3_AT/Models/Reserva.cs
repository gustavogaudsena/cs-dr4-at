using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DR3_AT.Models;

public class Reserva
{
    [Key]
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; }
    public int PacoteTuristicoId { get; set; }
    public PacoteTuristico PacoteTuristico { get; set; }
    public DateTime DataReserva { get; set; }
}