using DR3_AT.Interfaces;
using DR3_AT.Models;
using Microsoft.AspNetCore.Mvc;
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
    
    public IActionResult OnGet(int id)
    {

        var reservas = new List<Reserva>
        {
            new Reserva
            {
                Id = 1,
                PacoteTuristicoId = 1,
                DataReserva = DateTime.Now,
                ClienteId = 1
            }
        };
        
        Reserva = reservas.FirstOrDefault(r => r.Id == id);

        return Page();
    }
    
}