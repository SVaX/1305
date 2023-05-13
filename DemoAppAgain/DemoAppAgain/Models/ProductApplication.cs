using System;
using System.Collections.Generic;

namespace DemoAppAgain;

public partial class ProductApplication
{
    public int ProductApplicationId { get; set; }

    public int ProductId { get; set; }

    public int ApplicationId { get; set; }

    public virtual Application Application { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
