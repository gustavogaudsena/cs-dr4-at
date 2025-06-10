using DR3_AT.Data;
using DR3_AT.Interfaces;
using DR3_AT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DR3_AT.Pages.Reservas;

public class CreateReserva : PageModel
{
    private readonly AgenciaTurismoContext _context;

    [BindProperty]
    public Reserva Reserva { get; set; }

    public SelectList ClientesDisponiveis { get; set; }
    public SelectList PacotesDisponiveis { get; set; }
    public IPacoteTuristicoService _pacoteTuristicoService { get; set; }

    public CreateReserva(AgenciaTurismoContext context, IPacoteTuristicoService pacoteTuristicoService)
    {
        _context = context;
        _pacoteTuristicoService = pacoteTuristicoService;
    }
    public void OnGet()
    {
        var clientes = _context.Clientes.ToList();
        var pacotes = _context.Pacotes.ToList();
        
        ClientesDisponiveis = new SelectList(clientes, "Id", "Nome");
        PacotesDisponiveis = new SelectList(pacotes, "Id", "Titulo");
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var clientes = _context.Clientes.ToList();
        var pacotes = _context.Pacotes.ToList();
        
        ClientesDisponiveis = new SelectList(clientes, "Id", "Nome");
        PacotesDisponiveis = new SelectList(pacotes, "Id", "Titulo");
        
     
        Reserva.DataReserva = DateTime.Now;
        if (!ModelState.IsValid) return Page();
        
        bool reservaJaExiste = await _context.Reservas.AnyAsync(r => 
            r.ClienteId == Reserva.ClienteId && 
            r.PacoteTuristicoId == Reserva.PacoteTuristicoId);

        if (reservaJaExiste)
        {
            ModelState.AddModelError("", "Este cliente já possui uma reserva para este pacote.");
            return Page();
        }
        
        PacoteTuristico pacoteTuristico = await _context.Pacotes.Include(p => p.Reservas).FirstOrDefaultAsync(p => p.Id == Reserva.PacoteTuristicoId);
        bool isPacoteCheio = _pacoteTuristicoService.AddReservaIsValid(pacoteTuristico);

        if (!isPacoteCheio)
        {
            ModelState.AddModelError("", "Pacote já está cheio");
            return Page();
        }
        
        await _context.Reservas.AddAsync(Reserva);
        await _context.SaveChangesAsync();
        
        return RedirectToPage($"./DetailsReserva/", new { id = Reserva.Id }); 
    }
}