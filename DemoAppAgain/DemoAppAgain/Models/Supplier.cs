using System;
using System.Collections.Generic;

namespace DemoAppAgain;

public partial class Supplier
{
    public int SupplierId { get; set; }

    public string Name { get; set; } = null!;

    public string Tin { get; set; } = null!;

    public int CompanyTypeId { get; set; }

    public int MaterialHistoryId { get; set; }

    public virtual CompanyType CompanyType { get; set; } = null!;

    public virtual MaterialHistory MaterialHistory { get; set; } = null!;
}
