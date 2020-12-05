using IngeneosTest.Core.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IngeneosTest.EntityFrameworkCore.Repositories.Interfaces
{
    public interface IBookRepository
    {
        bool BookExist(int idBook);
        Task InsertAsync(Book book);
        Task<List<Book>> GetsAllAsync(int idAuthor, DateTime InitialPublishDate, DateTime FinalPublishDate);
        Task<Book> GetBookAsync(int idBook);
    }
}
