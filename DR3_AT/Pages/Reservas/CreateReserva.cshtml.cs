using DR3_AT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DR3_AT.Pages.Reservas;

public class CreateReserva : PageModel
{
    [BindProperty]
    public Reserva Reserva { get; set; }

    public SelectList ClientesDisponiveis { get; set; }
    public SelectList PacotesDisponiveis { get; set; }

    public void OnGet()
    {
        var clientes = new List<Cliente> { new Cliente { Id = 1, Nome = "Gustavo Sena" }, new Cliente { Id = 2, Nome = "Rinaldo Ferreira" } };
        var pacotes = new List<PacoteTuristico> { new PacoteTuristico { Id = 1, Titulo = "Férias em Cabo Frio" }, new PacoteTuristico { Id = 2, Titulo = "Passeio em Angra dos Reis" } };
        
        ClientesDisponiveis = new SelectList(clientes, "Id", "Nome");
        PacotesDisponiveis = new SelectList(pacotes, "Id", "Titulo");
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            OnGet();
            return Page();
        }

        Reserva.DataReserva = DateTime.Now;
        return RedirectToPage("./Index");
    }
}