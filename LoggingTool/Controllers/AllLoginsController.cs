using LoggingTool.Dtos;
using LoggingTool.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoggingTool.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AllLoginsController : ControllerBase
    {
        private readonly ILoginRepository loginRepo;
     

        public AllLoginsController(ILoginRepository loginRepo)
        {
            this.loginRepo = loginRepo;
            
        }
        [HttpGet("AllLogins")]
        public async Task<List<LoginDetails>> GetAll()
        {
            return await loginRepo.GetAll();
        }
    }
}
