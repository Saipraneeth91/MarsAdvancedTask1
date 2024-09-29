using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTask1.TestModel
{
    public class LoginModel
    {
        public ValidLoginModel ValidLogin { get; set; }
    }

    public class ValidLoginModel
    {
        public string Emailaddress { get; set; }
        public string Password { get; set; }
    }

}
