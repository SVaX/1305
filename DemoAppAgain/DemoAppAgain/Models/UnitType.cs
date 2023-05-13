using System;
using System.Collections.Generic;

namespace DemoAppAgain.Models;

public partial class UnitType
{
    public int UnitTypeId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();
}
