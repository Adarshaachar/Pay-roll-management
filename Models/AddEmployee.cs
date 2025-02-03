namespace PayRollmanagementSystem_Backend.Models
{
    public class AddEmployee
    {
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

    }
}
