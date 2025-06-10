using DR3_AT.Data;
using DR3_AT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DR3_AT.Pages.PacotesTuristicos;

public class DetailsPacoteTuristico : PageModel
{
    private readonly AgenciaTurismoContext _context;

    public PacoteTuristico PacoteTuristico { get; set; }

    public DetailsPacoteTuristico(AgenciaTurismoContext context)
    {
        _context = context;
    }
    public async void OnGetAsync(int id)
    {
        PacoteTuristico = await _context.Pacotes.Include(p => p.DestinosPacotes).ThenInclude(dp => dp.Destino).FirstOrDefaultAsync(p => p.Id == id);
    }
}