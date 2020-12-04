using IngeneosTest.EntityFrameworkCore.Repositories.Interfaces;
using IngeneosTest.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IngeneosTest.EntityFrameworkCore.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }
    }
}
