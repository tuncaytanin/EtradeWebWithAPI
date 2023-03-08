using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Token
{
    public class AppSettings
    {
        public string SecurityKey { get; set; }
        public int ExpiresDay { get; set; } = 0;
    }
}
