using System;
using System.Collections.Generic;

namespace Repositories.DataObjects;

public partial class User
{
    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public int Age { get; set; }

    public string Gender { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? GoogleId { get; set; }

    public virtual ICollection<Item> Items { get; } = new List<Item>();

    public virtual ICollection<Measurement> Measurements { get; } = new List<Measurement>();

    public virtual ICollection<Outfit> Outfits { get; } = new List<Outfit>();
}
