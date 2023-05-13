using System;
using System.Collections.Generic;

namespace DemoAppAgain.Models;

public partial class MaterialHistory
{
    public int MaterialHistoryId { get; set; }

    public int MaterialId { get; set; }

    public int OperationTypeId { get; set; }

    public DateTime Date { get; set; }

    public virtual Material Material { get; set; } = null!;

    public virtual OperationType OperationType { get; set; } = null!;

    public virtual ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();
}
