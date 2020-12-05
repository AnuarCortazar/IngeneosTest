using IngeneosTest.Application.Dto;
using IngeneosTest.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IngeneosTest.Application.Contract
{
    public interface IManageService
    {
        Task<bool> SynchronizeInformation();
        Task<BookDto> GetBookAsync(int idBook);
        Task<AuthorDto> GetAuthorAsync(int idBook);
        Task<List<BookDto>> GetAllBooksAsync(BookInput input);
        Task<List<AuthorDto>> GetAllAuthorsAsync(AuthorInput input);
        Task<AuthenticationResult> LoginUser(User user);
    }
}