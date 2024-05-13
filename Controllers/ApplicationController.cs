using AkshayTask.Models;
using AkshayTask.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AkshayTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationRepository _repository;

        public ApplicationController(IApplicationRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("submit")]
        public async Task<IActionResult> SubmitApplication([FromBody] Application application)
        {
            await _repository.SubmitApplicationAsync(application);
            return Ok();
        }
    }
}
