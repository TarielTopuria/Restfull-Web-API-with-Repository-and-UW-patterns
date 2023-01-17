using Microsoft.AspNetCore.Mvc;
using Restfull_Web_API_with_Repository_and_UW_patterns.Core.IConfiguration;
using Restfull_Web_API_with_Repository_and_UW_patterns.Models;

namespace Restfull_Web_API_with_Repository_and_UW_patterns.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller 
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public UsersController(ILogger<UsersController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            if(ModelState.IsValid)
            {
                user.Id = Guid.NewGuid();
                await _unitOfWork.Users.Add(user);
                await _unitOfWork.CompleteAsync();
                return CreatedAtAction("GetItem", new { user.Id }, user);
            }

            return new JsonResult("Something went wrong") { StatusCode = 500 };
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetItem(Guid Id) 
        {
            var user = await _unitOfWork.Users.GetById(Id);
            if(user == null)
            {
                return NotFound(); // 404 status code
            }

            return Ok(user); // 200 status code
        }
    }
}
