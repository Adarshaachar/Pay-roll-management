using System;
using System.Collections.Generic;

namespace PayRollmanagementSystem_Backend.Models;

public partial class Incentive
{
    public int IncentiveId { get; set; }

    public int? EmployeeId { get; set; }

    public decimal? Amount { get; set; }

    public string? Description { get; set; }

    public DateTime DateAwarded { get; set; }

    public virtual Employee? Employee { get; set; }
}
