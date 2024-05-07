using System;
using System.Collections.Generic;

namespace GG.Models;

public partial class Recipe
{
    public decimal Recipeid { get; set; }

    public decimal? Chefid { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public decimal? Categoryid { get; set; }

    public string? Approvalstatus { get; set; }

    public string? Imagefile { get; set; }

    public virtual Category? Category { get; set; }

    public virtual User? Chef { get; set; }

    public virtual ICollection<Reciperequest> Reciperequests { get; set; } = new List<Reciperequest>();

    public virtual ICollection<Testimonial> Testimonials { get; set; } = new List<Testimonial>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
