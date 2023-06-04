using DatabaseContext;
using Nybsys.DataAccess.Contracts;
using Nybsys.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nybsys.DataAccess.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(NybsysDbContext nybsysDbContext) : base(nybsysDbContext)
        {

        }
        // NybsysDbContext _db = new NybsysDbContext();
        //private readonly NybsysDbContext _db;
        //public EmployeeRepository(NybsysDbContext nybsysDbContext)
        //{
        //    _db = nybsysDbContext;
        //}
    }
}
