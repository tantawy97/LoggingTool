using LoggingTool.Dtos;
using LoggingTool.Model;
using LoggingTool.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoggingTool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository loginRepo;
        
        public LoginController(ILoginRepository loginRepo)
        {
            this.loginRepo = loginRepo;
        }
        [HttpGet]
        public async Task<List<Login>> GetAll()
        {
        return await loginRepo.GetAll();
        }
        [HttpPost]
        public  IActionResult Add(LoginDetails login)
        {
            if(login == null)
            {
               return BadRequest("Enter valid Data");
            }
           loginRepo.Add(login);
            return Ok(login);
        }
    }
}
