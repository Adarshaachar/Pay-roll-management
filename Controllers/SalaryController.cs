using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayRollmanagementSystem_Backend.Models;

namespace PayRollmanagementSystem_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryController : Controller
    {
        private EmpPayrollDbContext dbcontext;

        public SalaryController(EmpPayrollDbContext context)
        {
            dbcontext = context;
        }
        [HttpGet("ViewSalary")]
        public ActionResult GetSalary() {
            var salarydetails = dbcontext.Salaries.ToList();
            if(salarydetails.Any())
            {
                return Ok(salarydetails);
            }
            else
            {
                return BadRequest("No Salary details Found");
            }
        }
        [HttpPost("AddSalary")]
        public ActionResult AddSalary(AddSalary newsalary, int id)
        {
            var addsalary = new Salary
            {
                EmployeeId = id,
                BaseSalary = newsalary.BaseSalary,
                Taxes = newsalary.Taxes,
                SocialSecurity = newsalary.SocialSecurity,
                Incentives = newsalary.Incentives,
                TotalSalary = newsalary.TotalSalary,
                DateCredited = newsalary.DateCredited,

            };
            try
            {
                dbcontext.Salaries.Add(addsalary);
                dbcontext.SaveChanges();
                return Ok(new { message = "Salary  Added successfully" });
            }
            catch (DbUpdateException ex)

            {
                return BadRequest(ex);

            }
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

        [HttpGet("ViewIncentive")]
        public ActionResult GetIncenticve()
        {
            var incentivedetails = dbcontext.Incentives.ToList();
            if (incentivedetails.Any())
            {
                return Ok(incentivedetails);
            }
            else
            {
                return BadRequest("No Incentive data Found");
            }
        }

        [HttpPost("AddIncentive")]
        public ActionResult AddIncentive(AddIncentive newincentice, int empid)
        {
            var incentive = new Incentive
            {
                EmployeeId = empid,
                Amount = newincentice.Amount,
                Description = newincentice.Description,
                DateAwarded = newincentice.DateAwarded,

            };
            try
            {
                dbcontext.Incentives.Add(incentive);
                dbcontext.SaveChanges();
                return Ok(new { message = "Incentive  Added successfully" });
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex);

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
        [HttpPut("UpdateEmployee/{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] UpdateEmployeeModel model)
        {
            try
            {
                var employee = dbcontext.Employees.Find(id);
                if (employee == null)
                {
                    return NotFound($"Employee with id {id} not found");
                }

                employee.FirstName = model.FirstName ?? employee.FirstName;
                employee.LastName = model.LastName ?? employee.LastName;
                employee.Email = model.Email ?? employee.Email;
                employee.Phone = model.Phone ?? employee.Phone;
                employee.Address = model.Address ?? employee.Address;
                employee.Department = model.Department ?? employee.Department;
                employee.Position = model.Position ?? employee.Position;
                employee.Salary = model.Salary ?? employee.Salary;
                employee.HireDate = model.HireDate ?? employee.HireDate;
                dbcontext.SaveChanges();

                return Ok("Employee updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating employee: {ex.Message}");
            }
        }

    }
}
