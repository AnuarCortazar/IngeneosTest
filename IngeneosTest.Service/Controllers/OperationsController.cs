using IngeneosTest.Application.Contract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IngeneosTest.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationsController : ControllerBase
    {
        public readonly IManageService _manageService;

        public OperationsController(IManageService manageService)
        {
            _manageService = manageService;
        }

        public async Task<ActionResult> SynchronizeInformation()
        {
            return Ok(await _manageService.SynchronizeInformation());
        }
    }
}
