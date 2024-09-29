using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTask1.TestModel
{
    public class LanguageModel
    {
        public List<LanguageInfo> LanguageRecords { get; set; }
    }

    public class LanguageInfo
    {
        public string Addlanguage { get; set; }
        public string ChooseLanguageLevel { get; set; }
     
    }

}


