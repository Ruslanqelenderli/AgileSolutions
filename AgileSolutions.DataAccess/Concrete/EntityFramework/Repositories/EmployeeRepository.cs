using AgileSolutions.DataAccess.Abstract.IRepositories;
using AgileSolutions.DataAccess.Concrete.EntityFramework.Context;
using AgileSolutions.DataAccess.Concrete.EntityFramework.Repositories.GenericRepository;
using AgileSolutions.DataAccess.Concrete.ReturnResult;
using AgileSolutions.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileSolutions.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EmployeeRepository : EFGenericRepository<Employee, DataAccessReturnResult<Employee>, AgileSolutionsDbContext>, IEmployeeRepository
    {
        public EmployeeRepository(AgileSolutionsDbContext context) : base(context) { }

    }
}
