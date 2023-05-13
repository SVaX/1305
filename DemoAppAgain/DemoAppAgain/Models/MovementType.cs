using System;
using System.Collections.Generic;

namespace DemoAppAgain.Models;

public partial class MovementType
{
    public int MovementTypeId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<EmployeeMovement> EmployeeMovements { get; set; } = new List<EmployeeMovement>();
}
