using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileSolutions.Business.Helpers.ReturnResult
{
    public class BusinessReturnResult<TEntity>
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public ICollection<TEntity>? List { get; set; }
        public void MainMethod(string message, bool status, ICollection<TEntity>? list = null)
        {
            Message = message;
            Status = status;
            List = list;
        }
    }
}
