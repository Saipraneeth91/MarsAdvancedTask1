using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTask1.TestModel
{
    public class SearchskillFilterModel
    {
        public List<SearchSkillFilter> Searchskillfilter { get; set; }
    }
    public class SearchSkillFilter
    { 
        public string SkillCategory { get; set; }
        public string filterOption { get; set; }
    }
}
