using System;
using System.Collections.Generic;

namespace DemoAppAgain;

public partial class Application
{
    public int ApplicationId { get; set; }

    public int ManagerId { get; set; }

    public int AgentId { get; set; }

    public DateTime CreatingStartDate { get; set; }

    public DateTime CreatedDate { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public int ApplicationStatusId { get; set; }

    public bool PrepaymentIsMade { get; set; }

    public double SummaryCost { get; set; }

    public virtual Agent Agent { get; set; } = null!;

    public virtual ApplicationStatus ApplicationStatus { get; set; } = null!;

    public virtual ICollection<ProductApplication> ProductApplications { get; set; } = new List<ProductApplication>();
}
