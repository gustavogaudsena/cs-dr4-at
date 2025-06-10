using System.ComponentModel.DataAnnotations;
using DR3_AT.Data;
using DR3_AT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DR3_AT.Pages.PacotesTuristicos;

public class CreatePacoteTuristico : PageModel
{
    private readonly AgenciaTurismoContext _context;

    [BindProperty]
    public PacoteTuristico PacoteTuristico { get; set; }
    
    [BindProperty]
    [Required(ErrorMessage = "Selecione pelo menos um destino.")]
    public int[] SelectedDestinos { get; set; }

    public SelectList DestinosDisponiveis { get; set; }

    public CreatePacoteTuristico(AgenciaTurismoContext context)
    {
        _context = context;
    }
    public void OnGet()
    {
        var destinos = _context.Destinos.ToList();
        DestinosDisponiveis = new SelectList(destinos, "Id", "Nome");
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        await _context.Pacotes.AddAsync(PacoteTuristico);
        await _context.SaveChangesAsync();
        
        return RedirectToPage($"./DetailsPacoteTuristico/", new { id = PacoteTuristico.Id }); 
    }
}