using System;
using System.Collections.Generic;

namespace DemoAppAgain.Models;

public partial class Equipment
{
    public int EquipmentId { get; set; }

    public string Name { get; set; } = null!;

    public string RequiredSkill { get; set; } = null!;

    public int EquipmentStateId { get; set; }

    public virtual ICollection<EquipmentMaster> EquipmentMasters { get; set; } = new List<EquipmentMaster>();

    public virtual EquipmentState EquipmentState { get; set; } = null!;
}
