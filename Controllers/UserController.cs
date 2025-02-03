using Microsoft.AspNetCore.Mvc;
using PayRollmanagementSystem_Backend.Models;

namespace PayRollmanagementSystem_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private EmpPayrollDbContext dbcontext;

        public UserController(EmpPayrollDbContext context)
        {
            dbcontext = context;
        }
        [HttpGet("EmployeeViewById")]
        public ActionResult ViewEmployee(int empid)
        {
            var emp = dbcontext.Employees.FirstOrDefault(e => e.EmployeeId == empid);
            if (emp == null)
            {
                return BadRequest("Employee Not Found");
            }
            return Ok(emp);
        }
        [HttpGet("GetSalaryById")]
        public ActionResult GetSalaryById(int empId)
        {
            var salarydetails = dbcontext.Salaries.Where(e => e.EmployeeId == empId);
            if (salarydetails.Any())
            {
                return Ok(salarydetails);
            }
            else
            {
                return BadRequest("No Salary details Found On This Id");
            }
        }
        [HttpGet("GetIncentiveById")]
        public ActionResult GetIncentiveById(int empId)
        {
            var incentivedetails = dbcontext.Incentives.Where(e => e.EmployeeId == empId);
            if (incentivedetails.Any())
            {
                return Ok(incentivedetails);
            }
            else
            {
                return BadRequest("No Incentive  details Found On This Id");
            }
        }


    }
}
