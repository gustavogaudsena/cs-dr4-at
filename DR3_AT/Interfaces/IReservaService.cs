using DR3_AT.Models;

namespace DR3_AT.Interfaces;

public interface IReservaService
{
    void AddNewReserva(Reserva reserva);
    decimal CalculateValorFinalReserva(Reserva reserva);

}