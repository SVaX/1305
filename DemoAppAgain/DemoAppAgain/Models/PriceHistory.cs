using System;
using System.Collections.Generic;

namespace DemoAppAgain;

public partial class PriceHistory
{
    public int PriceHistoryId { get; set; }

    public int ProductId { get; set; }

    public double OldPrice { get; set; }

    public double NewPrice { get; set; }

    public DateTime Date { get; set; }

    public virtual Product Product { get; set; } = null!;
}
