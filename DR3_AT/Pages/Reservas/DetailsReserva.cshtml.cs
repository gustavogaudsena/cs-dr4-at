using DR3_AT.Data;
using DR3_AT.Interfaces;
using DR3_AT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DR3_AT.Pages.Reservas;

public class DetailsReserva : PageModel
{
    private readonly AgenciaTurismoContext _context;
    public Reserva Reserva { get; set; }
    public IReservaService _reservaService { get; set; }
    
    public DetailsReserva (AgenciaTurismoContext context, IReservaService reservaService)
    {
        _reservaService = reservaService;
        _context = context;
    }
    
    public async void OnGetAsync(int id)
    {
        Reserva = await _context.Reservas.Include(r => r.Cliente).Include(r => r.PacoteTuristico).FirstOrDefaultAsync(r => r.Id == id);
    }
    
}