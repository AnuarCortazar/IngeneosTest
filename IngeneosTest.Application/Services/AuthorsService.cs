using IngeneosTest.Application.Contract;
using IngeneosTest.Application.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IngeneosTest.Application.Services
{
    public partial class ManageService : IManageService
    {
        public async Task<AuthorDto> GetAuthorAsync(int idBook)
        {
            return _mapper.Map<AuthorDto>(await UnitOfWork.Books.GetBookAsync(idBook));
        }

        public async Task<List<AuthorDto>> GetAllAuthorsAsync()
        {
            var books = _mapper.Map<List<AuthorDto>>(await UnitOfWork.Authors.GetsAllAsync());
            return books;
        }
    }
}
