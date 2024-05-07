using System;
using System.Collections.Generic;

namespace GG.Models;

public partial class Role
{
    public decimal Roleid { get; set; }

    public string? Rolename { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
