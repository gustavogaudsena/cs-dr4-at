using DR3_AT.Interfaces;
using DR3_AT.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DR3_AT.Pages.Reservas;

public class DetailsReserva : PageModel
{
    public Reserva Reserva { get; set; }
    public IReservaService _reservaService { get; set; }
    
    public DetailsReserva ( IReservaService reservaService)
    {
        _reservaService = reservaService;
    }
    
    public void OnGet(int id)
    {
        // Mock de reserva simples
        Reserva = new Reserva();
        Reserva.Id = id;
        PacoteTuristico pacote = new PacoteTuristico();
        pacote.Preco = 10.5m;
        pacote.DataInicio = DateTime.Now;
        pacote.DataFinal = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 3, 23, 59, 59);
        Reserva.PacoteTuristico = pacote;
    }
    
    
}