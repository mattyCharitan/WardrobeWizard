using System;
using System.Collections.Generic;

namespace Repositories.DataObjects;

public partial class Measurement
{
    public int MeasurementsId { get; set; }

    public decimal Height { get; set; }

    public decimal Weight { get; set; }

    public decimal Waist { get; set; }

    public decimal Bust { get; set; }

    public decimal Hip { get; set; }

    public string? Size { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
