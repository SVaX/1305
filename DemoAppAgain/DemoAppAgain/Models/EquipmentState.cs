using System;
using System.Collections.Generic;

namespace DemoAppAgain.Models;

public partial class EquipmentState
{
    public int EquipmentStateId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Equipment> Equipment { get; set; } = new List<Equipment>();
}
