using DR3_AT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DR3_AT.Pages.PacotesTuristicos;

public class DetailsPacoteTuristico : PageModel
{
    public PacoteTuristico PacoteTuristico { get; set; }

    public IActionResult OnGet(int id)
    {
        var destinos = new List<Destino>
        {
            new Destino { Id = 1, Nome = "Rio de Janeiro", Pais = "Brasil" },
            new Destino { Id = 2, Nome = "Angra dos Reis", Pais = "Brasil" },
            new Destino { Id = 3, Nome = "Cabo Frio", Pais = "Brasil" }
        };

        var pacotes = new List<PacoteTuristico>
        {
            new PacoteTuristico
            {
                Id = 1, Titulo = "Férias em Cabo Frio", DataInicio = DateTime.Now.AddDays(10),
                DataFinal = DateTime.Now.AddDays(30), Destinos = new List<Destino> { destinos[2]} , CapacidadeMaxima = 20, Preco = 150.0m
            },
            new PacoteTuristico
            {
                Id = 2, Titulo = "Passeio em Angra dos Reis", DataInicio = DateTime.Now.AddDays(30),
                DataFinal = DateTime.Now.AddDays(35), Destinos = new List<Destino> { destinos[1]}, CapacidadeMaxima = 10, Preco = 350.0m
            }
        };
        
        PacoteTuristico = pacotes.FirstOrDefault(p => p.Id == id);

        return Page();
    }
}