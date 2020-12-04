using IngeneosTest.EntityFrameworkCore;

namespace IngeneosTest.EntityFrameworkCore.Repositories
{
    public abstract class RepositoryBase
    {
        public AppDbContext DbContext { get; set; }
        public RepositoryBase(AppDbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}
