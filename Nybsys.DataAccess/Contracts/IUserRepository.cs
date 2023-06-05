using Nybsys.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nybsys.DataAccess.Contracts
{
	public interface IUserRepository
	{
		bool Create(User employee);
		bool Update(User employee);
		bool Delete(User employee);
		User GetById(int id);
		ICollection<User> GetAll();
	}
}
