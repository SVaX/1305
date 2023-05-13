using System;
using System.Collections.Generic;

namespace DemoAppAgain.Models;

public partial class Material
{
    public int MaterialId { get; set; }

    public string Name { get; set; } = null!;

    public int MaterialTypeId { get; set; }

    public int SupplierId { get; set; }

    public int QuantityInPackage { get; set; }

    public int UnitTypeId { get; set; }

    public int QuantityInStock { get; set; }

    public double MinCost { get; set; }

    public string? Description { get; set; }

    public string? Picture { get; set; }

    public double Cost { get; set; }

    public virtual ICollection<ManufactureMaterial> ManufactureMaterials { get; set; } = new List<ManufactureMaterial>();

    public virtual ICollection<MaterialHistory> MaterialHistories { get; set; } = new List<MaterialHistory>();

    public virtual MaterialType MaterialType { get; set; } = null!;

    public virtual UnitType UnitType { get; set; } = null!;
}
