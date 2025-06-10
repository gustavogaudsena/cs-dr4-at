using System;
using System.Collections.Generic;

namespace DR3_AT.MigrationsScaffold;

public partial class Cliente
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool IsDeleted { get; set; } = false;
    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
