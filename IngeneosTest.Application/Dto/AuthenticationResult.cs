using System;
using System.Collections.Generic;
using System.Text;

namespace IngeneosTest.Application.Dto
{
    public class AuthenticationResult
    {
        public string Token { get; set; }
        public bool Success { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
