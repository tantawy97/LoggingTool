using AutoMapper;
using LoggingTool.Dtos;
using LoggingTool.Model;
using LoggingTool.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoggingTool.Controllers
{
    [Authorize(Roles ="User")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository loginRepo;
        private readonly ILogger<LoginController> logger;

        public LoginController(ILoginRepository loginRepo , ILogger<LoginController> logger)
        {
            this.loginRepo = loginRepo;
            this.logger = logger;
        }
       
        [HttpGet]
        public async Task<List<LoginDetails>> GetByUserId([FromBody] string id)
        {
            return await loginRepo.GetByUserId(id);
        }
        [HttpPost]
        public IActionResult Add(LoginDetails loginDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Enter valid Data");
            }
            loginRepo.Add(loginDetails);
            logger.LogInformation("Added Successfully");
            return Ok(loginDetails);
        }
        [HttpPut("{id}")]
        public IActionResult Edit(int id,LoginDetails loginDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Enter valid Data");
            }
            logger.LogInformation("Updated Successfully");
            loginRepo.Edit(id, loginDetails);
            return Ok("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest("Enter valid Id");
            }
            loginRepo.Delete(id);
            return Ok("Deleted Successfully");
        }
    }
}
