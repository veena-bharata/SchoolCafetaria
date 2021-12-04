using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafetaria.Common.Helpers.Dtos
{
    
        public class LoginDto
        {
            public Data Data { get; set; }
        }
        public class Data
        {
            public string Browser { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public string Url { get; set; }
        }
    }

