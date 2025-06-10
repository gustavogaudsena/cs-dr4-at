using DR3_AT.Data;
using DR3_AT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DR3_AT.Pages.Destinos;

public class DetailsDestino : PageModel
{
    private readonly AgenciaTurismoContext _context;

    public DetailsDestino(AgenciaTurismoContext context)
    {
        _context = context;
    }
    public Destino Destino { get; set; }

    public async void OnGetAsync(int id)
    {
        Destino = await _context.Destinos.FirstOrDefaultAsync(d => d.Id == id);
    }
}