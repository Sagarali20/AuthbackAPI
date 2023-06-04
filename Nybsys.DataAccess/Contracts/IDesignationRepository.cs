using Nybsys.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nybsys.DataAccess.Contracts
{
    public interface IDesignationRepository
    {
        ICollection<EDesignation> GetAll();

    }
}
