using System;
using System.Collections.Generic;

namespace DemoAppAgain.Models;

public partial class Master
{
    public int MasterId { get; set; }

    public int EmployeeId { get; set; }

    public bool HasFamily { get; set; }

    public string? HealthProblems { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual ICollection<EquipmentMaster> EquipmentMasters { get; set; } = new List<EquipmentMaster>();
}
