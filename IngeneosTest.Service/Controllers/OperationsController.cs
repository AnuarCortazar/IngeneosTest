using IngeneosTest.Application.Contract;
using IngeneosTest.Application.Dto;
using IngeneosTest.Core.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IngeneosTest.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class OperationsController : ControllerBase
    {
        public readonly IManageService _manageService;

        public OperationsController(IManageService manageService)
        {
            _manageService = manageService;
        }

        [Route("sync")]
        [HttpGet]
        public async Task<ActionResult> SynchronizeInformation()
        {
            return Ok(await _manageService.SynchronizeInformation());
        }
        [Route("authors")]
        [HttpGet]
        public async Task<ActionResult> GetAuthors()
        {
            return Ok(await _manageService.GetAllAuthorsAsync());
        }
        [Route("authors/{idAuthor}")]
        [HttpGet]
        public async Task<ActionResult> GetAuthorsById(int idAuthor)
        {
            return Ok(await _manageService.GetAuthorAsync(idAuthor));
        }
        [Route("books")]
        [HttpPost]
        public async Task<ActionResult> GetBooks(BookInput input)
        {
            return Ok(await _manageService.GetAllBooksAsync(input));
        }
        [Route("books/{idBook}")]
        [HttpGet] 
        public async Task<ActionResult> GetBooksById(int idBook)
        {
            return Ok(await _manageService.GetBookAsync(idBook));
        }
    }
}
