using AgileSolutions.Business.Abstract.Services;
using AgileSolutions.Business.Concrete.Dtos.EmployeeDtos;
using AgileSolutions.Business.Helpers.ReturnResult;
using AgileSolutions.DataAccess.Abstract.IRepositories;
using AgileSolutions.Entity.Entities;
using AutoMapper;

namespace AgileSolutions.Business.Concrete.Managers
{
    public class EmployeeManager : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IMapper mapper;

        public EmployeeManager(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            this.employeeRepository = employeeRepository;
            this.mapper = mapper;
        }
        public async Task<BusinessReturnResult<EmployeeGetDto>> AddAsync(EmployeeAddDto dto)
        {
            try
            {
                var data = mapper.Map<Employee>(dto);
                data.CreatedDate = DateTime.Now;
                data.IsDeleted = false;
                var returnresult = await employeeRepository.AddAsync(data);
                var result = mapper.Map<BusinessReturnResult<EmployeeGetDto>>(returnresult);
                return result;
            }
            catch (Exception ex)
            {
                var result = new BusinessReturnResult<EmployeeGetDto>();
                result.MainMethod(ex.Message, false);
                return result;
            }
        }

        public async Task<BusinessReturnResult<EmployeeGetDto>> DeleteAsync(int Id)
        {
            try
            {
                var returnresult = await employeeRepository.DeleteAsync(Id);
                var result = mapper.Map<BusinessReturnResult<EmployeeGetDto>>(returnresult);
                return result;
            }
            catch (Exception ex)
            {
                var result = new BusinessReturnResult<EmployeeGetDto>();
                result.MainMethod(ex.Message, false);
                return result;
            }
        }

        public async Task<BusinessReturnResult<EmployeeGetDto>> GetAllForStateAsync(bool enableTracking = true, params string[] include)
        {
            try
            {
                var result = await employeeRepository.GetAllAsync(x => x.State == true && x.IsDeleted == false,
                                                      enableTracking,
                                                      include);
                var returnresult = mapper.Map<BusinessReturnResult<EmployeeGetDto>>(result);
                return returnresult;

            }
            catch (Exception ex)
            {
                var returnresult = new BusinessReturnResult<EmployeeGetDto>();
                returnresult.MainMethod(ex.Message, false);
                return returnresult;
                ;
            }
        }

        public async Task<BusinessReturnResult<EmployeeGetDto>> GetByIdAsync(int id, params string[] include)
        {
            try
            {
                var result = await employeeRepository.GetAsync(x => x.Id == id,
                                                      include);
                var returnresult = mapper.Map<BusinessReturnResult<EmployeeGetDto>>(result);
                return returnresult;

            }
            catch (Exception ex)
            {
                var returnresult = new BusinessReturnResult<EmployeeGetDto>();
                returnresult.MainMethod(ex.Message, false);
                return returnresult;
                ;
            }
        }

        public async Task<BusinessReturnResult<EmployeeGetDto>> UpdateAsync(EmployeeUpdateDto dto)
        {
            try
            {
                var data = mapper.Map<Employee>(dto);
                var returnresult = await employeeRepository.UpdateAsync(data);
                var result = mapper.Map<BusinessReturnResult<EmployeeGetDto>>(returnresult);
                return result;
            }
            catch (Exception ex)
            {
                var result = new BusinessReturnResult<EmployeeGetDto>();
                result.MainMethod(ex.Message, false);
                return result;
            }
        }
    }
}
