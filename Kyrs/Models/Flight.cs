using System;
using System.Collections.Generic;

namespace Kyrs.Model;

public partial class Flight
{
    public int NumberFlight { get; set; }

    public string Аirplane { get; set; } = null!;

    public string Departure { get; set; } = null!;

    public string Destination { get; set; } = null!;

    public string Date { get; set; } = null!;

    public string TimeDeparture { get; set; } = null!;

    public string TimeFlight { get; set; } = null!;

    public decimal Price { get; set; }
}
