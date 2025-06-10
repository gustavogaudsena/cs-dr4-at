using System.ComponentModel.DataAnnotations;

namespace DR3_AT.Models;

public class Cliente
{
    [Key]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "O nome do cliente é obrigatório.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 100 caracteres.")]
    public string Nome { get; set; }
    
    [Required(ErrorMessage = "O e-mail é obrigatório.")]
    [EmailAddress(ErrorMessage = "Formato de e-mail inválido.")]
    public string Email { get; set; }
    
    public ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}