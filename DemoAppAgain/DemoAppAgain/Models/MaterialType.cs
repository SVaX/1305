using System;
using System.Collections.Generic;

namespace DemoAppAgain.Models;

public partial class MaterialType
{
    public int MaterialTypeId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();
}
