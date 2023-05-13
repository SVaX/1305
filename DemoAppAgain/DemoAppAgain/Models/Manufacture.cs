using System;
using System.Collections.Generic;

namespace DemoAppAgain;

public partial class Manufacture
{
    public int ManufactureId { get; set; }

    public int ProductId { get; set; }

    public int WorkshopId { get; set; }

    public int PeopleRequired { get; set; }

    public TimeSpan TimeRequired { get; set; }

    public virtual ICollection<ManufactureMaterial> ManufactureMaterials { get; set; } = new List<ManufactureMaterial>();

    public virtual Product Product { get; set; } = null!;

    public virtual Workshop ProductNavigation { get; set; } = null!;
}
