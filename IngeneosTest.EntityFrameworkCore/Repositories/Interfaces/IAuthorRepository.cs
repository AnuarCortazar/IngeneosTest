using IngeneosTest.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IngeneosTest.EntityFrameworkCore.Repositories.Interfaces
{
    public interface IAuthorRepository
    {
        bool AuthorExist(int idAuthor);
        Task InsertAsync(Author author);
        Task<List<Author>> GetsAllAsync();
        Task<Author> GetByIdAsync(int idAuthor);
    }
}
