using System;
using System.Collections.Generic;

namespace DemoAppAgain;

public partial class SalePoint
{
    public int SalePointId { get; set; }

    public string Name { get; set; } = null!;

    public int AgentId { get; set; }

    public string Address { get; set; } = null!;

    public virtual Agent Agent { get; set; } = null!;
}
