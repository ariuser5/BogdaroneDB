using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DbAccess.Services
{
	[ServiceContract(Name = "IUserService")]
	public interface IUsersService
	{
		[OperationContract(Name = "Read")]
		[WebGet(
			UriTemplate = "ReadUsers", 
			ResponseFormat = WebMessageFormat.Json)]
		IEnumerable<User> Read(/*string username*/);

	}


}
