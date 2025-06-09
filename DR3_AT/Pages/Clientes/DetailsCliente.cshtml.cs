using DR3_AT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DR3_AT.Pages.Clientes;

public class DetailsCliente : PageModel
{
    public Cliente Cliente { get; set; }

    public IActionResult OnGet(int id)
    {
        var clientes = new List<Cliente> { new Cliente { Id = 1, Nome = "Gustavo Sena" , Email = "sena@mail.com"}, new Cliente { Id = 2, Nome = "Rinaldo Ferreira" , Email = "rinaldo@mail.com"} };

        Cliente = clientes.FirstOrDefault(c => c.Id == id);
     
        return Page();
    }
}