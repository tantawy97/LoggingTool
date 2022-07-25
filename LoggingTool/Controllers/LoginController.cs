using AutoMapper;
using LoggingTool.Dtos;
using LoggingTool.Model;
using LoggingTool.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoggingTool.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository loginRepo;


        public LoginController(ILoginRepository loginRepo)
        {
            this.loginRepo = loginRepo;
        }
        [HttpGet("Logins")]
        public async Task<List<LoginDetails>> GetAll()
        {
            return await loginRepo.GetAll();
        }
        [HttpPost]
        public IActionResult Add(LoginDetails loginDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Enter valid Data");
            }
            loginRepo.Add(loginDetails);
            return Ok(loginDetails);
        }
        [HttpPut("{id}")]
        public IActionResult Edit(int id,LoginDetails loginDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Enter valid Data");
            }
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
