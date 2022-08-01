using LoggingTool.Dtos;
using LoggingTool.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoggingTool.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly ILogger<LoginController> logger;

        public UserController(IUserRepository userRepository, ILogger<LoginController> logger)
        {
            this.userRepository = userRepository;
            this.logger = logger;
        }
        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody] LoginDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await userRepository.SignIn(model);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);
            logger.LogInformation($" \n {model.Email} Logged In at {DateTime.Now}");
            return Ok(result);
        }
    }
}
