using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DbAccess.Services
{
	[ServiceContract(Name = "IUserService")]
	public interface IUsersService
	{
		[OperationContract(Action = "ReadUser", Name = "Read")]
		IEnumerable<User> Read(string username);

	}


}
