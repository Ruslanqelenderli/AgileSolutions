using AgileSolutions.Business.Concrete.Dtos.EmployeeDtos;
using AgileSolutions.Business.Helpers.ReturnResult;

namespace AgileSolutions.Business.Abstract.Services
{
    public interface IEmployeeService
    {
        Task<BusinessReturnResult<EmployeeGetDto>> GetAllForStateAsync(bool enableTracking = true, params string[] include);
        Task<BusinessReturnResult<EmployeeGetDto>> AddAsync(EmployeeAddDto dto);
        Task<BusinessReturnResult<EmployeeGetDto>> UpdateAsync(EmployeeUpdateDto dto);
        Task<BusinessReturnResult<EmployeeGetDto>> GetByIdAsync(int id, params string[] include);
        Task<BusinessReturnResult<EmployeeGetDto>> DeleteAsync(int Id);
    }
}
