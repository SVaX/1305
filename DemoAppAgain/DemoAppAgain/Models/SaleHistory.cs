using System;
using System.Collections.Generic;

namespace DemoAppAgain.Models;

public partial class SaleHistory
{
    public int SaleHistoryId { get; set; }

    public int ProductId { get; set; }

    public int AgentId { get; set; }

    public DateTime Date { get; set; }

    public int Quantity { get; set; }

    public double SummaryCost { get; set; }

    public virtual Product Product { get; set; } = null!;
}
