using System;
using System.Collections.Generic;

namespace PayRollmanagementSystem_Backend.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public int? UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public string? Department { get; set; }

    public string? Position { get; set; }

    public decimal? Salary { get; set; }

    public DateTime HireDate { get; set; }

  

    public bool IsActive { get; set; }

    public string Gender { get; set; } = null!;

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

 

    public virtual ICollection<Incentive> Incentives { get; set; } = new List<Incentive>();

    public virtual ICollection<Salary> Salaries { get; set; } = new List<Salary>();


}
