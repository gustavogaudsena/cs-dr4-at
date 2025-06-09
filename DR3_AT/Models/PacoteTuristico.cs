using System.ComponentModel.DataAnnotations;

namespace DR3_AT.Models;

public class PacoteTuristico
{
    public int Id { get; set; }
    
    [Display(Name = "Título do pacote")]
    [Required(ErrorMessage = "O título é obrigatório.")]
    [StringLength(100, MinimumLength = 5, ErrorMessage = "O título deve ter entre 5 e 100 caracteres.")]
    public string Titulo { get; set; }
    
    [Display(Name = "Data de início")]
    [Required(ErrorMessage = "A data de início é obrigatória.")]
    [DataType(DataType.Date)]
    public DateTime DataInicio { get; set; }
    
    [Display(Name = "Data final")]
    [Required(ErrorMessage = "A data final é obrigatória.")]
    [DataType(DataType.Date)]
    public DateTime DataFinal { get; set; }
    
    [Display(Name = "Capacidade Maxima")]
    [Required(ErrorMessage = "A capacidade máxima é obrigatória.")]
    [Range(1, 1000, ErrorMessage = "A capacidade deve ser no mínimo 1.")]
    public int CapacidadeMaxima { get; set; }
   
    [Display(Name = "Preço da diária")]
    [Required(ErrorMessage = "O preço é obrigatório.")]
    [Range(0.01, 100000.00, ErrorMessage = "O preço deve ser um valor positivo.")]
    public decimal Preco { get; set; }
    
    public List<Destino> Destinos { get; set; }
    public List<Reserva> Reservas { get; set; }
}