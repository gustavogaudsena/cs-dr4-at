using DR3_AT.Interfaces;
using DR3_AT.Models;

namespace DR3_AT.Services;

public class ReservaService : IReservaService
{
    private readonly LogService _logService = new LogService();
    
    public void AddNewReserva(Reserva Reserva)
    {
        Action<string> logOperation;
        logOperation = _logService.LogToConsole;
        logOperation += _logService.LogToFile;
        logOperation += _logService.LogToMemory;
        
        // Lógica de criar uma reserva -- Será feita posteriormente;

        string logMessage = $"Reserva do pacote {Reserva.PacoteTuristico.Titulo} registrada no nome de {Reserva.Cliente.Nome}";
        logOperation(logMessage);
    }
    
    public decimal CalculateValorFinalReserva(Reserva Reserva)
    {
        
        // Utilizei Func<int, decimal, decimal> pois preço em pacote turistico está em decimal
        Func<int, decimal, decimal> calcularValorFinalReserva = (numeroDias, precoPorDia) => numeroDias * precoPorDia;
        
        TimeSpan dataFinal = Reserva.PacoteTuristico.DataFinal.Subtract(Reserva.PacoteTuristico.DataInicio);
        int diasTotaisReserva = dataFinal.Days;
        decimal valorFinalReserva = calcularValorFinalReserva(diasTotaisReserva, Reserva.PacoteTuristico.Preco);

        return valorFinalReserva;

    }
    
}