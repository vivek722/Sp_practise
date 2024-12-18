using Domain.Model.BaseEntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class EmployeeEntity : BaseEntity
    {
        public string name { get; set; }
        public string age { get; set; }
        public string mno { get; set; }
        public string emailid { get; set; }
        public string image { get; set; }
        //public List<SkillEntity> skills { get; set; }
    }
}
