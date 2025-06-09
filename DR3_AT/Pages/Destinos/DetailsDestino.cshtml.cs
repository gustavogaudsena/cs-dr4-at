using DR3_AT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DR3_AT.Pages.Destinos;

public class DetailsDestino : PageModel
{
    public Destino Destino { get; set; }

    public IActionResult OnGet(int id)
    {
        var destinos = new List<Destino>
        {
            // Mocks para testar a funcionalidade até a implementação do banco de dados na etapa 3
            new Destino { Id = 1, Nome = "Rio de Janeiro", Pais = "Brasil" },
            new Destino { Id = 2, Nome = "Angra dos Reis", Pais = "Brasil" },
            new Destino { Id = 3, Nome = "Cabo Frio", Pais = "Brasil" }
        };

        Destino = destinos.FirstOrDefault(d => d.Id == id);

      
        return Page();
    }
}