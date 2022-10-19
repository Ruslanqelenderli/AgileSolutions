using AgileSolutions.Business.Concrete.Dtos.DepartmentDtos;
using AgileSolutions.Business.Helpers.ReturnResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileSolutions.Business.Abstract.Services
{
    public interface IDepartmentService
    {
        Task<BusinessReturnResult<DepartmentGetDto>> GetAllForStateAsync(bool enableTracking = true, params string[] include);
        Task<BusinessReturnResult<DepartmentGetDto>> AddAsync(DepartmentAddDto dto);
        Task<BusinessReturnResult<DepartmentGetDto>> UpdateAsync(DepartmentUpdateDto dto);
        Task<BusinessReturnResult<DepartmentGetDto>> GetByIdAsync(int id, params string[] include);
        Task<BusinessReturnResult<DepartmentGetDto>> DeleteAsync(int Id);
    }
}
