using System;
using System.Collections.Generic;
using System.Text;

namespace IngeneosTest.Application.Dto
{
    public class BookInput
    {
        public int IdAuthor { get; set; }
        public DateTime InitialPublishDate { get; set; }
        public DateTime FinalPublishDate { get; set; }
    }
}
