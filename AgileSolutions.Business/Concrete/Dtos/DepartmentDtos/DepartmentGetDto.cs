using AgileSolutions.Business.Concrete.Dtos.EmployeeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileSolutions.Business.Concrete.Dtos.DepartmentDtos
{
    public class DepartmentGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentDepartmentId { get; set; }
        public DepartmentGetDto ParentDepartment { get; set; }
        public ICollection<EmployeeGetDto> EmployeeGetDtos { get; set; }
    }
}
