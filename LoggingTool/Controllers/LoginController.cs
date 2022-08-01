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
        public async Task<List<LoginDetailsDto>> GetByUserId([FromBody] string id)
        {
            return await loginRepo.GetByUserId(id);
        }
        [HttpPost]
        public IActionResult Add(LoginDetailsDto loginDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Enter valid Data");
            }
            loginRepo.Add(loginDetails);
            logger.LogInformation($"\n Added Successfully UserName: {loginDetails.UserName} \n Website: {loginDetails.Website} ");
            return Ok(loginDetails);
        }
        [HttpGet("{id}")]
        public IActionResult GetEdit(int id)
        {
            if (id == 0) {
                return BadRequest();
            }
            return Ok(loginRepo.GetbyId(id));
        }
            [HttpPut("Put")]
        public IActionResult Put([FromBody]LoginDetailsDto loginDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Enter valid Data");
            }
            logger.LogInformation($"\n Updated Successfully UserName: {loginDetails.UserName} \n Website: {loginDetails.Website} ");
            loginRepo.Edit(loginDetails.Id, loginDetails);
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
