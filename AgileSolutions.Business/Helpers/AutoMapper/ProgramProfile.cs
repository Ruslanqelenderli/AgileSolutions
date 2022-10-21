using AgileSolutions.Business.Concrete.Dtos.DepartmentDtos;
using AgileSolutions.Business.Concrete.Dtos.EmployeeDtos;
using AgileSolutions.Business.Helpers.ReturnResult;
using AgileSolutions.DataAccess.Concrete.ReturnResult;
using AgileSolutions.Entity.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileSolutions.Business.Helpers.AutoMapper
{
    public class ProgramProfile:Profile
    {
        public ProgramProfile()
        {
            

            CreateMap<Department, DepartmentAddDto>().ReverseMap();
            CreateMap<Department, DepartmentGetDto>()
                .ForMember(x=>x.EmployeeGetDtos,opt=>opt.MapFrom(x=>x.Employees)).ReverseMap();
            CreateMap<Department, DepartmentUpdateDto>().ReverseMap();
            CreateMap<BusinessReturnResult<DepartmentGetDto>, DataAccessReturnResult<Department>>().ReverseMap();

            CreateMap<Employee, EmployeeAddDto>().ReverseMap();
            CreateMap<Employee, EmployeeUpdateDto>().ReverseMap();
            CreateMap<Employee, EmployeeGetDto>()
                .ForMember(x => x.DepartmentName, opt => opt.MapFrom(x => x.Department.Name)).ReverseMap();
            CreateMap<BusinessReturnResult<EmployeeGetDto>, DataAccessReturnResult<Employee>>().ReverseMap();

        }
    }
}
