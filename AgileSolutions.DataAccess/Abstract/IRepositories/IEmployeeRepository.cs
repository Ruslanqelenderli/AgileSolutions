using AgileSolutions.DataAccess.Abstract.GenericRepository;
using AgileSolutions.DataAccess.Concrete.ReturnResult;
using AgileSolutions.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileSolutions.DataAccess.Abstract.IRepositories
{
    public interface IEmployeeRepository : IAsyncRepository<Employee, DataAccessReturnResult<Employee>>, IRepository<Employee, DataAccessReturnResult<Employee>>
    {
    }
}
