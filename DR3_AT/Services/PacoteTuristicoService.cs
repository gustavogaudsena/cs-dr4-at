using System.Data;
using DR3_AT.Interfaces;
using DR3_AT.Models;

namespace DR3_AT.Services;

public class PacoteTuristicoService :IPacoteTuristicoService
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

    public bool AddReservaIsValid(PacoteTuristico pacoteTuristico)
    {
        CapacityReached = m => Console.WriteLine(m);

        Console.WriteLine(pacoteTuristico.Reservas.Count );
        if (pacoteTuristico.Reservas.Count >= pacoteTuristico.CapacidadeMaxima)
        {
            OnCapacityReached("Capacidade maxima de reservas já atingida");
            return false;
        }

        return true;
    }
    
    protected virtual void OnCapacityReached(string message)
    {
        CapacityReached?.Invoke(message);

    } 
}