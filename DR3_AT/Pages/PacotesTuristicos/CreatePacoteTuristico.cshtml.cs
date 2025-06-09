using System.ComponentModel.DataAnnotations;
using DR3_AT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DR3_AT.Pages.PacotesTuristicos;

public class CreatePacoteTuristico : PageModel
{
    
    [BindProperty]
    public PacoteTuristico PacoteTuristico { get; set; }
    
    [BindProperty]
    [Required(ErrorMessage = "Selecione pelo menos um destino.")]
    public int[] SelectedDestinos { get; set; }

    public SelectList DestinosDisponiveis { get; set; }

    public void OnGet()
    {
        var destinos = new List<Destino>
        {
            // Mocks para testar a funcionalidade até a implementação do banco de dados na etapa 3
            new Destino { Id = 1, Nome = "Rio de Janeiro", Pais = "Brasil" },
            new Destino { Id = 2, Nome = "Angra dos Reis", Pais = "Brasil" },
            new Destino { Id = 3, Nome = "Cabo Frio", Pais = "Brasil" }
        };
        
        DestinosDisponiveis = new SelectList(destinos, "Id", "Nome");

    }
    
    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            OnGet(); 
            return Page();
        }

        // Cria o pacote e adiciona no banco de dados que será integrado na parte 3
        // await _context.PacoteTuristico.AddAsync(Destino);
        
        return RedirectToPage("./Index");
    }
}