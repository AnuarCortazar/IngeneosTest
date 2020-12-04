using IngeneosTest.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IngeneosTest.EntityFrameworkCore.Repositories.Interfaces
{
    public interface IBookRepository
    {
        bool BookExist(int idBook);
        Task InsertAsync(Book book);
        Task<List<Book>> GetsAllAsync();
        Task<Book> GetBookAsync(int idAuthor);
    }
}
