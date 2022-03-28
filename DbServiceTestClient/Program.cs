using System;
using System.Linq;
using System.Text;

namespace DbServiceTestClient
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");

			using(var client = new UsersService.UserServiceClient(
				endpointConfiguration: UsersService.UserServiceClient
					.EndpointConfiguration.NetTcpBinding_IUserService)) 
			{
				Transact(client);

				Console.WriteLine("Press any key to exit...");
				Console.ReadKey();
			}
		}


		static void Transact(UsersService.UserServiceClient client)
		{
			const string EXIT_CMD = "quit";

			var repeat = true;

			do {
				Console.Write("Username:");

				var input = Console.ReadLine();

				if(input == EXIT_CMD) {
					repeat = false;
				} else {

					var responseTask = client.ReadAsync(input);
					var response = responseTask.Result;
					var foundUser = response.FirstOrDefault(u => u.Name == input);

					if(foundUser is null == false) {
						var userData = SerializeUser(response.First());

						Console.WriteLine("Found user:");
						Console.WriteLine(userData);
					} else {
						Console.WriteLine(
							$"no user with username '{input}' was found.");
					}
				}

			} while(repeat); 
		}

		static string SerializeUser(UsersService.User user)
		{
			var sb = new StringBuilder();

			sb.AppendLine("{");
			sb.AppendLine($"\tname: {user.Name},");
			sb.AppendLine($"\tpassword: {user.Password},");
			sb.AppendLine("}");

			return sb.ToString();
		}

	}
}
