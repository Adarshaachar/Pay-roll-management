namespace PayRollmanagementSystem_Backend.Models
{
    public class AddSalary
    {

        public decimal? BaseSalary { get; set; }

        public decimal? Taxes { get; set; }

        public decimal? SocialSecurity { get; set; }

        public decimal? Incentives { get; set; }

        public decimal? TotalSalary { get; set; }

        public DateTime DateCredited { get; set; }
    }
}
