using System;
using System.Collections.Generic;

namespace DemoAppAgain.Models;

public partial class EquipmentMaster
{
    public int EquipmentMasterId { get; set; }

    public int EquipmentId { get; set; }

    public int MasterId { get; set; }

    public virtual Equipment Equipment { get; set; } = null!;

    public virtual Master Master { get; set; } = null!;
}
