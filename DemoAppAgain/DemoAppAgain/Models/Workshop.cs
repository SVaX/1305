using System;
using System.Collections.Generic;

namespace DemoAppAgain.Models;

public partial class Workshop
{
    public int WorkshopId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Manufacture> Manufactures { get; set; } = new List<Manufacture>();
}
