using System;
using System.Collections.Generic;

namespace DemoAppAgain;

public partial class CompanyType
{
    public int CompanyTypeId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Agent> Agents { get; set; } = new List<Agent>();

    public virtual ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();
}
