
using AutoMapper;
using IngeneosTest.Application.Contract;
using IngeneosTest.Core.Configuration;
using IngeneosTest.Core.Helpers;
using IngeneosTest.Core.Model;
using IngeneosTest.EntityFrameworkCore;
using IngeneosTest.EntityFrameworkCore.UnitOfWork;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IngeneosTest.Application.Services
{
    public partial class ManageService : IManageService
    {
        readonly string fakeServiceUrlBase;
        readonly IMapper _mapper;
        readonly JwtSettings _jwtSettings;
        public IConfiguration Configuration { get; set; }
        private IUnitOfWork UnitOfWork { get; set; }
        public ManageService(AppDbContext context, IConfiguration configuration, IMapper mapper, JwtSettings jwtSettings)
        {
            _mapper = mapper;
            _jwtSettings = jwtSettings;
            UnitOfWork = new UnitOfWork(context);
            fakeServiceUrlBase = configuration.GetSection("fakeServiceUri").Value;            
        }

        public async Task<bool> SynchronizeInformation()
        {
            var resultBooks = await SynchronizeBooks();
            if (resultBooks) return await SynchronizeAuthors();
            else return false;
        }

        private async Task<bool> SynchronizeBooks()
        {
            var books = JsonConvert.DeserializeObject<List<Book>>(await HttpServiceClient.Get(fakeServiceUrlBase + "Books"));
            
            foreach (var book in books)
            {
                if (!UnitOfWork.Books.BookExist(book.Id))
                {
                    await UnitOfWork.Books.InsertAsync(book);                    
                }
            }

            return UnitOfWork.SaveChanges() > 0;
        }

        private async Task<bool> SynchronizeAuthors()
        {
            var authors = JsonConvert.DeserializeObject<List<Author>>(await HttpServiceClient.Get(fakeServiceUrlBase + "Authors"));

            foreach (var author in authors)
            {
                if (!UnitOfWork.Authors.AuthorExist(author.Id))
                {
                    if (!UnitOfWork.Books.BookExist(author.IdBook))
                    {
                        await SynchronizeBookById(author.IdBook);
                    }

                    await UnitOfWork.Authors.InsertAsync(author);
                }
            }

            return UnitOfWork.SaveChanges() > 0;
        }

        private async Task<bool> SynchronizeBookById(int idBook)
        {
            var book = JsonConvert.DeserializeObject<Book>(await HttpServiceClient.Get(fakeServiceUrlBase + "Books/" + idBook.ToString()));

            if (book.Id == 0) return false;
            
            await UnitOfWork.Books.InsertAsync(book);
            return UnitOfWork.SaveChanges() > 0;            
        }
    }
}
