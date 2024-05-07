using System;
using System.Collections.Generic;

namespace GG.Models;

public partial class Category
{
    public decimal Categoryid { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
}
