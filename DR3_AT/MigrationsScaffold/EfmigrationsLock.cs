﻿using System;
using System.Collections.Generic;

namespace DR3_AT.MigrationsScaffold;

public partial class EfmigrationsLock
{
    public int Id { get; set; }

    public string Timestamp { get; set; } = null!;
}
