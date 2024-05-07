using System;
using System.Collections.Generic;

namespace GG.Models;

public partial class Transaction
{
    public decimal Transactionid { get; set; }

    public decimal? Userid { get; set; }

    public decimal? Recipeid { get; set; }

    public decimal? Amount { get; set; }

    public string? Paymentstatus { get; set; }

    public DateTime? Paymentdate { get; set; }

    public virtual Recipe? Recipe { get; set; }

    public virtual User? User { get; set; }
}
