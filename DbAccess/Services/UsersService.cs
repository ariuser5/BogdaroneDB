using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DbAccess.Services
{
	public class UsersService: IUsersService
	{
		public IEnumerable<User> Read(string username)
		{
			using(var context = new BogdaroneDbContext()) {
				//var user = new User()
				//{
				//	Name = "admin",
				//	Password = "admin"
				//};


				return context.Users.ToArray();

				//context.Users.Add(user);
				//context.SaveChanges();
			}
		}
	}
}
