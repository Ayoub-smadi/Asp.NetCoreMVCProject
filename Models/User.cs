using System;
using System.Collections.Generic;

namespace GG.Models;

public partial class User
{
    public decimal Userid { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public decimal? Roleid { get; set; }
    
    public bool? Isactive { get; set; }

    public string? Imagefile { get; set; }

    public virtual ICollection<Reciperequest> Reciperequests { get; set; } = new List<Reciperequest>();

    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();

    public virtual Role? Role { get; set; }

    public virtual ICollection<Testimonial> Testimonials { get; set; } = new List<Testimonial>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
