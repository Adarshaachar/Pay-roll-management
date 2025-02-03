using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayRollmanagementSystem_Backend.Models;
using System.Security.Cryptography;
using System.Text;

namespace PayRollmanagementSystem_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private EmpPayrollDbContext dbcontext;
        private readonly IConfiguration _configuration;

        public AdminController(EmpPayrollDbContext dbContext, IConfiguration configuration)
        {
            dbcontext = dbContext;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public ActionResult Login(LoginModel model)
        {    
                var admin = dbcontext.AdminDetails.Where(x => x.email == model.email && x.password == model.password);

                if (admin == null)
                {
                    return Unauthorized("Invalid email or password");
                }

                return Ok("login succesfull");
            }
        }
    }


