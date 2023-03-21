using System;
using System.Collections.Generic;

namespace Repositories.DataObjects;

public partial class Outfit
{
    public int OutfitId { get; set; }

    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual ICollection<Item> Items { get; } = new List<Item>();
}
