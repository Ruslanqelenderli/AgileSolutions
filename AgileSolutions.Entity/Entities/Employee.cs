using AgileSolutions.Entity.Entities.CommonEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileSolutions.Entity.Entities
{
    public class Employee:BaseEntity
    {
        public Employee(string name, string surname, string email, int departmentId):this()
        {
            Name = name;
            Surname = surname;
            Email = email;
            DepartmentId = departmentId;
        }
        public Employee()
        {

        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
