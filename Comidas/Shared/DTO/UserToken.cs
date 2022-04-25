using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comidas.Shared.DTO
{
    public class UserToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
