using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTask1.TestModel
{
    public class SearchskillCategoryModel
    {
        public List<SearchSkill> SearchskillRecords{ get; set; }
    }
    public class SearchSkill
    {
        public string Category { get; set; }
    }
}

