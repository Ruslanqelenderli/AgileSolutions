using AgileSolutions.Business.Abstract.Services;
using AgileSolutions.Business.Concrete.Dtos.DepartmentDtos;
using AgileSolutions.Business.Helpers.ReturnResult;
using AgileSolutions.DataAccess.Abstract.IRepositories;
using AgileSolutions.Entity.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileSolutions.Business.Concrete.Managers
{
    public class DepartmentManager : IDepartmentService
    {
        private readonly IDepartmentRepository departmentRepository;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IMapper mapper;
        public DepartmentManager(IDepartmentRepository departmentRepository, IMapper mapper, IEmployeeRepository employeeRepository)
        {
            this.departmentRepository = departmentRepository;
            this.mapper = mapper;
            this.employeeRepository = employeeRepository;
        }
        public async Task<BusinessReturnResult<DepartmentGetDto>> AddAsync(DepartmentAddDto dto)
        {
            try
            {
                var data = mapper.Map<Department>(dto);
                data.CreatedDate = DateTime.Now;
                data.IsDeleted = false;
                var returnresult = await departmentRepository.AddAsync(data);
                var result = mapper.Map<BusinessReturnResult<DepartmentGetDto>>(returnresult);
                return result;
            }
            catch (Exception ex)
            {
                var result = new BusinessReturnResult<DepartmentGetDto>();
                result.MainMethod(ex.Message, false);
                return result;
            }
        }

        public async Task<BusinessReturnResult<DepartmentGetDto>> DeleteAsync(int Id)
        {
            try
            {
                var employees = await employeeRepository.GetAllAsync(x=>x.DepartmentId==Id);
                var deleteresult = await employeeRepository.DeleteRangeAsync(employees.List);
                var returnresult = await departmentRepository.DeleteAsync(Id);
                var result = mapper.Map<BusinessReturnResult<DepartmentGetDto>>(returnresult);
                return result;
            }
            catch (Exception ex)
            {
                var result = new BusinessReturnResult<DepartmentGetDto>();
                result.MainMethod(ex.Message, false);
                return result;
            }
        }

        public async Task<BusinessReturnResult<DepartmentGetDto>> GetAllForStateAsync(bool enableTracking = true, params string[] include)
        {
            try
            {
                var result = await departmentRepository.GetAllAsync(x => x.State == true && x.IsDeleted == false,
                                                      enableTracking,
                                                      include);
                var returnresult = mapper.Map<BusinessReturnResult<DepartmentGetDto>>(result);
                return returnresult;

            }
            catch (Exception ex)
            {
                var returnresult = new BusinessReturnResult<DepartmentGetDto>();
                returnresult.MainMethod(ex.Message, false);
                return returnresult;
                ;
            }
        }

        public async Task<BusinessReturnResult<DepartmentGetDto>> GetByIdAsync(int id, params string[] include)
        {
            try
            {
                var result = await departmentRepository.GetAsync(x => x.Id == id,
                                                      include);
                var returnresult = mapper.Map<BusinessReturnResult<DepartmentGetDto>>(result);
                return returnresult;

            }
            catch (Exception ex)
            {
                var returnresult = new BusinessReturnResult<DepartmentGetDto>();
                returnresult.MainMethod(ex.Message, false);
                return returnresult;
                ;
            }
        }

        public async Task<BusinessReturnResult<DepartmentGetDto>> UpdateAsync(DepartmentUpdateDto dto)
        {
            try
            {
                var data = mapper.Map<Department>(dto);
                var returnresult = await departmentRepository.UpdateAsync(data);
                var result = mapper.Map<BusinessReturnResult<DepartmentGetDto>>(returnresult);
                return result;
            }
            catch (Exception ex)
            {
                var result = new BusinessReturnResult<DepartmentGetDto>();
                result.MainMethod(ex.Message, false);
                return result;
            }
        }
    }
}
