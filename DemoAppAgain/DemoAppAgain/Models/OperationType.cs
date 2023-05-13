using System;
using System.Collections.Generic;

namespace DemoAppAgain;

public partial class OperationType
{
    public int OperationTypeId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<MaterialHistory> MaterialHistories { get; set; } = new List<MaterialHistory>();
}
