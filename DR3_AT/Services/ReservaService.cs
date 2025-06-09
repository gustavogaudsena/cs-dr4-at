using DR3_AT.Models;

namespace DR3_AT.Services;

public class ReservaService
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
    
}