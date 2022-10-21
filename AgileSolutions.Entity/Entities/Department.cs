using AgileSolutions.Entity.Entities.CommonEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileSolutions.Entity.Entities
{
    public class Department:BaseEntity
    {
        public Department(string name):this()
        {
            Name = name;
        }
        public Department()
        {

        }
        public int? ParentDepartmentId { get; set; }
        public Department ParentDepartment { get; set; }
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
