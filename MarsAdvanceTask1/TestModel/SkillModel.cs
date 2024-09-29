using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTask1.TestModel
{
    public class SkillModel
    {
        public List<SkillInfo> SkillRecords { get; set; }
    }
    public class SkillInfo
    {
        public string AddSkill { get; set; }
        public string ChooseSkill { get; set; }
    }
}