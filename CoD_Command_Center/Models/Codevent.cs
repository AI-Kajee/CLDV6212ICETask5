using System;
using System.Collections.Generic;

namespace CoD_Command_Center.Models;

public partial class Codevent
{
    public int EId { get; set; }

    public string? EventName { get; set; }

    public string? EventDetails { get; set; }

    public DateOnly? EStartDate { get; set; }

    public DateOnly? EEndDate { get; set; }
}
