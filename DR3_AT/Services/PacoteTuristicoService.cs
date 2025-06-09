using DR3_AT.Models;

namespace DR3_AT.Services;

public class PacoteTuristicoService
{
    public delegate decimal CalculateDelegate(decimal originalPrice);
    
    public DiscountService DiscountService { get; set; } = new DiscountService();
    public CalculateDelegate CalculateDiscount { get; set; }

    public decimal CalculaPrecoFinalDoPacote(PacoteTuristico pacoteTuristico)
    {
        CalculateDiscount = DiscountService.Calculate10PercentDiscount;
        return CalculateDiscount(pacoteTuristico.Preco);
    }
}