using System;
using System.Collections.Generic;

namespace Kyrs.Model;

public partial class Passenger
{
    public string SurName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public int DocumentSerial { get; set; }

    public int DocumentNumber { get; set; }

    public int NumberFlight { get; set; }

    public string Date { get; set; } = null!;

    public virtual Flight NumberFlightNavigation { get; set; } = null!;
}
