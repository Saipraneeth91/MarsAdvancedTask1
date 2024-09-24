using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTask1.TestModel
{

    public class UserDetailmodel
    {
        public List<UserInfo> UserDetails { get; set; }
    }

    public class UserInfo
    {

        public string availableTime { get; set; }
        public string availableHours { get; set; }
        public string earnTarget { get; set; }
    }

}

