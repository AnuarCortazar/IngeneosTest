using IngeneosTest.Application.Contract;
using IngeneosTest.Application.Dto;
using IngeneosTest.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IngeneosTest.Application.Services
{
    public partial class ManageService : IManageService
    {
        public async Task<BookDto> GetBookAsync(int idBook)
        {
            return _mapper.Map<BookDto>(await UnitOfWork.Books.GetBookAsync(idBook));
        }

        public async Task<List<BookDto>> GetAllBooksAsync(BookInput input)
        {
            var books = await UnitOfWork.Books.GetsAllAsync(input.IdAuthor, input.InitialPublishDate, input.FinalPublishDate);
            return _mapper.Map<List<BookDto>>(books);
        }
    }
}
