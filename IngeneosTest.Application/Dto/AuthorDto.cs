﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IngeneosTest.Application.Dto
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }        
        public BookDto Book { get; set; }
    }
}
