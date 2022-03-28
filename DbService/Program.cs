using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace DbService
{
	class Program
	{
		static void Main(string[] args)
		{

			using(var host = new ServiceHost(typeof(DbAccess.UsersService))) {
				host.Open();
				Console.WriteLine("Host started @ " + DateTime.Now.ToString());
				Console.ReadLine();
			}

		}


	}
}
