using Nybsys.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nybsys.DataAccess.Contracts
{
    public interface IEmployeeTRepository
    {
        bool Create(EmployeeT employee);
        bool Update(EmployeeT employee);
        bool Delete(EmployeeT employee);
        EmployeeT GetById(int id);
        ICollection<EmployeeT> GetAll();
    }
}
