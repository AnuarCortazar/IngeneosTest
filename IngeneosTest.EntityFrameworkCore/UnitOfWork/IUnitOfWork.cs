using IngeneosTest.EntityFrameworkCore.Repositories.Interfaces;

namespace IngeneosTest.EntityFrameworkCore.UnitOfWork
{
    public interface IUnitOfWork
    {
        IAuthorRepository Authors { get; }
        IBookRepository Books { get; }
        IUserRepository Users { get; }
        int SaveChanges();
    }
}
