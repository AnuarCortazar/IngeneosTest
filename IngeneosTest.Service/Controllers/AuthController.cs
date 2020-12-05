using IngeneosTest.Application.Contract;
using IngeneosTest.Core.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IngeneosTest.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public readonly IManageService _manageService;

        public AuthController(IManageService manageService)
        {
            _manageService = manageService;
        }

        [Route("login")]
        [HttpPost]
        public async Task<ActionResult> LoginUser(User user)
        {
            return Ok(await _manageService.LoginUser(user));
        }
    }
}
