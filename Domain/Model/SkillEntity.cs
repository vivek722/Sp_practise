using Domain.Model.BaseEntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class SkillEntity : BaseEntity
    {
        public string Skillname { get; set; }
        public int Empid { get; set; }
       // public EmployeeEntity Employee { get; set; }
    }
}
