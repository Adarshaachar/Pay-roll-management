using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PayRollmanagementSystem_Backend.Models;
using System.Data;

namespace PayRollmanagementSystem_Backend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private EmpPayrollDbContext dbcontext;
        private readonly IConfiguration _configuration;

        public EmployeeController(EmpPayrollDbContext dbContext, IConfiguration configuration)
        {
            dbcontext = dbContext;
            _configuration = configuration;
        }


        [HttpGet("EmployeeView")]
        public ActionResult ViewEmployee()
        {
            var emp = dbcontext.Employees.ToList();
            if (emp.Count == 0)
            {
                return BadRequest("No items Found");
            }
            return Ok(emp);
        }
        [HttpGet("EmployeeViewById")]
        public ActionResult ViewEmployee(int empid)
        {
            var emp=dbcontext.Employees.FirstOrDefault(e=>e.EmployeeId==empid);
            if(emp == null)
            {
                return BadRequest("Employee Not Found");
            }
            return Ok(emp);
        }
        [HttpPost("AddEmployee")]
        public ActionResult AddNewEmployee(AddEmployee emp)

        {
            var newemp = new Employee
            {
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                Email = emp.Email,
                Phone = emp.Phone,
                Position = emp.Position,
                Address = emp.Address,
                Salary = emp.Salary,
                HireDate = emp.HireDate,
                IsActive = emp.IsActive,
                Gender = emp.Gender,


            };
            try
            {
                dbcontext.Employees.Add(newemp);
                dbcontext.SaveChanges();
                return Ok(new { message = "Employee Added successfully" });
            }
            catch (DbUpdateException ex)

            {
                return BadRequest(ex);

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
        [HttpDelete("DeletingEmployee/{id}")]
        public ActionResult DeleteEmployee(int id)
        {
            var employee = dbcontext.Users.FirstOrDefault(e=>e.UserId==id);
            if (employee == null)
            {
                return NotFound();
            }
            dbcontext.Users.Remove(employee);
            dbcontext.SaveChanges();

            return Ok(new { message = "Employee deleted successfully" });
        }
       
    }
}