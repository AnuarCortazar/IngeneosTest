using IngeneosTest.EntityFrameworkCore.Repositories;
using IngeneosTest.EntityFrameworkCore.Repositories.Interfaces;
using IngeneosTest.EntityFrameworkCore;

namespace IngeneosTest.EntityFrameworkCore.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public AppDbContext Context { get; }
        IBookRepository _book;
        IAuthorRepository _author;
        public UnitOfWork(AppDbContext context) => Context = context;

        public IAuthorRepository Authors { get { if (_author == null) { _author = new AuthorRepository(Context); } return _author; } }

        public IBookRepository Books { get { if (_book == null) { _book = new BooksRepository(Context); } return _book; } }

        public int SaveChanges() { return Context.SaveChanges(); }
    }
}
