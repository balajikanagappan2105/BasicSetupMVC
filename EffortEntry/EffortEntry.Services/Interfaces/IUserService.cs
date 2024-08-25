using EffortEntry.Domain.Models;
using EffortEntry.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffortEntry.Services.Interfaces
{
	public interface IUserService
	{
		string login();
		ResponseModel CreateUser(User user);
		ResponseModel UpdateUser(User user);
		IEnumerable<User> GetUsers();
	}
}
