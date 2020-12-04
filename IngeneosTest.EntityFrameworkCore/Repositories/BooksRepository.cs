using IngeneosTest.EntityFrameworkCore.Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using IngeneosTest.Core.Model;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<Book>> GetsAllAsync()
        {
            return await DbContext.Books.ToListAsync();
        }

        public async Task<Book> GetBookAsync(int idAuthor)
        {
            return await DbContext.Books.FirstOrDefaultAsync(p => p.Id == idAuthor);
        }
    }
}
