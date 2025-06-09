using System.ComponentModel.DataAnnotations;

namespace DR3_AT.Models;

public class Destino
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "O nome do destino é obrigatório.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome do destino deve ter pelo menos 3 caracteres.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O país é obrigatório.")]
    public string Pais { get; set; }
}