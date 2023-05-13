using System;
using System.Collections.Generic;

namespace DemoAppAgain.Models;

public partial class ProductStandart
{
    public int ProductStandartId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
