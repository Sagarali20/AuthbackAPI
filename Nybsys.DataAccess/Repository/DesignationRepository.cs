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
    public class DesignationRepository : BaseRepository<EDesignation>,IDesignationRepository
    {
        public DesignationRepository(NybsysDbContext nybsysDbContext) : base(nybsysDbContext)
        {
        }
    }
}
