using System;
using System.Collections.Generic;

namespace Repositories.DataObjects;

public partial class Item
{
    public int ItemId { get; set; }

    public int UserId { get; set; }

    public string? Category { get; set; }

    public string? Color { get; set; }

    public string? Style { get; set; }

    public string? Brand { get; set; }

    public string? Size { get; set; }

    public string? ImageUrl { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual ICollection<Outfit> Outfits { get; } = new List<Outfit>();
}
