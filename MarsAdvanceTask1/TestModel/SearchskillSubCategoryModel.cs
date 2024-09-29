using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTask1.TestModel
{
    public class SearchskillsubcategoryModel
    {
        public List<SearchSubSkill> SearchsubskillRecords { get; set; }
    }
    public class SearchSubSkill
    { 
        public string Category { get; set; }
        public string SubCategory { get; set; }


    }
}

