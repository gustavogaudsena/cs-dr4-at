using System;
using System.Collections.Generic;

namespace DR3_AT.MigrationsScaffold;

public partial class Pacote
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public DateTime DataInicio { get; set; }

    public DateTime DataFinal { get; set; }

    public int CapacidadeMaxima { get; set; }

    public decimal Preco { get; set; }

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();

    public virtual ICollection<Destino> Destinos { get; set; } = new List<Destino>();
}
