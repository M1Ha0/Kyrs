using System;
using System.Collections.Generic;

namespace Kyrs.Model;

public partial class FreePlace
{
    public int NumberFlight { get; set; }

    public string Date { get; set; } = null!;

    public int TotalPlace { get; set; }

    public int? FreePlace1 { get; set; }

    public virtual Flight NumberFlightNavigation { get; set; } = null!;
}
