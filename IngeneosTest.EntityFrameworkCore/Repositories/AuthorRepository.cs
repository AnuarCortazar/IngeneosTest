using IngeneosTest.EntityFrameworkCore.Repositories.Interfaces;
using IngeneosTest.Core.Model;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace IngeneosTest.EntityFrameworkCore.Repositories
{
    public class AuthorRepository : RepositoryBase, IAuthorRepository
    {
        public AuthorRepository(AppDbContext context) : base(context)
        {
        }

        public bool AuthorExist(int idAuthor) => DbContext.Authors.Count(p => p.Id == idAuthor) > 0;

        public async Task InsertAsync(Author author)
        {            
            await DbContext.Authors.AddAsync(author);            
        }

        public async Task<List<Author>> GetsAllAsync()
        {
            return await DbContext.Authors.Include(p => p.Book).ToListAsync();
        }

        public async Task<Author> GetByIdAsync(int idAuthor)
        {
            return await DbContext.Authors.FirstOrDefaultAsync(p => p.Id == idAuthor);
        }
    }
}
