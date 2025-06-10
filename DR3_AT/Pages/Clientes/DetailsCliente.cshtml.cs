using DR3_AT.Data;
using DR3_AT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DR3_AT.Pages.Clientes;

public class DetailsCliente : PageModel
{
    private readonly AgenciaTurismoContext _context;
    public Cliente Cliente { get; set; }

    public DetailsCliente(AgenciaTurismoContext context)
    {
        _context = context;
    }

    public async void OnGetAsync(int id)
    {
        Cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id);
    }
}