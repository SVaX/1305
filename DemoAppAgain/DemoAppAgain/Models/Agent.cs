using System;
using System.Collections.Generic;

namespace DemoAppAgain;

public partial class Agent
{
    public int AgentId { get; set; }

    public string Name { get; set; } = null!;

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Logo { get; set; }

    public string LegalAddress { get; set; } = null!;

    public int Priority { get; set; }

    public string Principal { get; set; } = null!;

    public string Tin { get; set; } = null!;

    public string Kpp { get; set; } = null!;

    public double? TotalImplementation { get; set; }

    public int CompanyTypeId { get; set; }

    public int? SaleQuantity { get; set; }

    public int? Sale { get; set; }

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();

    public virtual CompanyType CompanyType { get; set; } = null!;

    public virtual ICollection<SalePoint> SalePoints { get; set; } = new List<SalePoint>();
}
