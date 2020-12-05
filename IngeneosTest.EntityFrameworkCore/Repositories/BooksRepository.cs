using IngeneosTest.EntityFrameworkCore.Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using IngeneosTest.Core.Model;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System;

namespace IngeneosTest.EntityFrameworkCore.Repositories
{
    public class BooksRepository : RepositoryBase, IBookRepository
    {
        public BooksRepository(AppDbContext context) : base(context)
        {
        }

        public bool BookExist(int idBook) => DbContext.Books.Count(p => p.Id == idBook) > 0;

        public async Task InsertAsync(Book book)
        {
            await DbContext.Books.AddAsync(book);         
        }

        public async Task<List<Book>> GetsAllAsync(int idAuthor, DateTime InitialPublishDate, DateTime FinalPublishDate)
        {
            var books = DbContext.Books
                                 .Where(p => 
                                    (p.Id == idAuthor || idAuthor == 0) && 
                                    (InitialPublishDate.Year == 1 || (p.PublishDate <= InitialPublishDate && p.PublishDate >= FinalPublishDate)));
            return await books.ToListAsync();
        }

        public async Task<Book> GetBookAsync(int idBook)
        {
            return await DbContext.Books.FirstOrDefaultAsync(p => p.Id == idBook);
        }
    }
}
