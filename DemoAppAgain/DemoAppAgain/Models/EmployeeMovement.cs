using System;
using System.Collections.Generic;

namespace DemoAppAgain.Models;

public partial class EmployeeMovement
{
    public int EmployeeMovementId { get; set; }

    public int EmployeeId { get; set; }

    public string Place { get; set; } = null!;

    public int MovementTypeId { get; set; }

    public DateTime Date { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual MovementType MovementType { get; set; } = null!;
}
