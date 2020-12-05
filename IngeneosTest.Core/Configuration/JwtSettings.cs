using System;

namespace IngeneosTest.Core.Configuration
{
    public class JwtSettings
    {
        public string SecretKey { get; set; }
        public TimeSpan TokenLifetime { get; set; }
    }
}
