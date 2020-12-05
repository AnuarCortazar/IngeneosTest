using IngeneosTest.Application.Dto;
using IngeneosTest.Core.Model;

namespace IngeneosTest.Application.Profiles
{
    public class Profile : AutoMapper.Profile
    {
        public Profile()
        {
            CreateMap<Book, BookDto>();
            CreateMap<Author, AuthorDto>();
        }
    }
}
