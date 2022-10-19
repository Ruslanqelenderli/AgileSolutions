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
    public interface IDepartmentRepository:IAsyncRepository<Department,DataAccessReturnResult<Department>>, IRepository<Department, DataAccessReturnResult<Department>>
    {
    }
}
