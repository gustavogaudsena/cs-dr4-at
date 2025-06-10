using DR3_AT.Data;
using DR3_AT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DR3_AT.Pages.Clientes;

public class CreateCliente : PageModel
{
    private readonly AgenciaTurismoContext _context;

    [BindProperty]
    public Cliente Cliente { get; set; } = new();

    public CreateCliente(AgenciaTurismoContext context)
    {
        _context = context;
    }
    public void OnGet()
    {
        
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        await _context.Clientes.AddAsync(Cliente);
        await _context.SaveChangesAsync();
        
        return RedirectToPage($"./DetailsCliente/", new { id = Cliente.Id }); 
    }
}