using System;
using System.Collections.Generic;

namespace PayRollmanagementSystem_Backend.Models;

public partial class Salary
{
    public int SalaryId { get; set; }

    public int? EmployeeId { get; set; }

    public decimal? BaseSalary { get; set; }

    public decimal? Taxes { get; set; }

    public decimal? SocialSecurity { get; set; }

    public decimal? Incentives { get; set; }

    public decimal? TotalSalary { get; set; }

    public DateTime DateCredited { get; set; }

    public virtual Employee? Employee { get; set; }
}
