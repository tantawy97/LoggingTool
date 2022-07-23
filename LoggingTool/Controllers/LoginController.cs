using AutoMapper;
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
        private readonly IMapper imapper;

        public LoginController(ILoginRepository loginRepo, IMapper imapper)
        {
            this.loginRepo = loginRepo;
            this.imapper = imapper;
        }
        [HttpGet]
        public async Task<List<Login>> GetAll()
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
    }
}
