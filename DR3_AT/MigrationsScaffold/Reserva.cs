using System;
using System.Collections.Generic;

namespace DR3_AT.MigrationsScaffold;

public partial class Reserva
{
    public int Id { get; set; }

    public int ClienteId { get; set; }

    public int PacoteTuristicoId { get; set; }

    public DateTime DataReserva { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual Pacote PacoteTuristico { get; set; } = null!;
}
