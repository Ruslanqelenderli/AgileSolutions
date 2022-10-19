using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileSolutions.Business.Concrete.Dtos.EmployeeDtos
{
    public class EmployeeAddDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
    }
}
