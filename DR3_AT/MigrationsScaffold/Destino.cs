using System;
using System.Collections.Generic;

namespace DR3_AT.MigrationsScaffold;

public partial class Destino
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Pais { get; set; } = null!;

    public virtual ICollection<Pacote> Pacotes { get; set; } = new List<Pacote>();
}
