using DR3_AT.Models;

namespace DR3_AT.Interfaces;

public interface IPacoteTuristicoService
{
    decimal CalculaPrecoFinalDoPacote(PacoteTuristico pacoteTuristico);
    bool AddReservaIsValid(PacoteTuristico pacoteTuristico);

}