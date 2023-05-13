using System;
using System.Collections.Generic;

namespace DemoAppAgain.Models;

public partial class ManufactureMaterial
{
    public int ManufactureMaterialId { get; set; }

    public int ManufactureId { get; set; }

    public int MaterialId { get; set; }

    public virtual Manufacture Manufacture { get; set; } = null!;

    public virtual Material Material { get; set; } = null!;
}
