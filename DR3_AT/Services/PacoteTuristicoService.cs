using System.Data;
using DR3_AT.Models;

namespace DR3_AT.Services;

public class PacoteTuristicoService
{
    public delegate decimal CalculateDelegate(decimal originalPrice);
    public DiscountService DiscountService { get; set; } = new DiscountService();
    public CalculateDelegate CalculateDiscount { get; set; }
    public event Action<string> CapacityReached;

    public decimal CalculaPrecoFinalDoPacote(PacoteTuristico pacoteTuristico)
    {
        CalculateDiscount = DiscountService.Calculate10PercentDiscount;
        return CalculateDiscount(pacoteTuristico.Preco);
    }

    public void AddReserva(PacoteTuristico pacoteTuristico, Reserva reserva)
    {
        if (pacoteTuristico.Reservas.Count >= pacoteTuristico.CapacidadeMaxima)
        {
            OnCapacityReached("Capacidade maxima de reservas já atingida");
            return;
        }
        
        pacoteTuristico.Reservas.Add(reserva);
    }
    
    protected virtual void OnCapacityReached(string message)
    {
        CapacityReached?.Invoke(message);
    } 
}