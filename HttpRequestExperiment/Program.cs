using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HttpRequestExperiment
{
	class Program
	{
		static async Task Main(string[] args)
		{
			using(var client = new HttpClient()) {
				await ProcessRepositories(client);
			}
				Console.WriteLine("Hello World!");
		}

		private async static Task ProcessRepositories(HttpClient client)
		{
			var headerValue = new MediaTypeWithQualityHeaderValue(
				mediaType: "application/vnd.github.v3+json");

			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(headerValue);
			client.DefaultRequestHeaders.Add(
				name: "User-Agent",
				value: ".NET Foundation Repository Reporter");


			//var responseTask = client.GetAsync(
			//	requestUri: "https://api.github.com/orgs/dotnet/repos");

			var responseTask = client.GetAsync(
				requestUri: "http://localhost:8080/ReadUsers/");

			var msg = (string)null;

			using(var response = await responseTask)
			using(var stream = response.Content.ReadAsStream())
			using(var sr = new StreamReader(stream)) {
				msg = sr.ReadToEnd();
			}

			Console.Write(msg);
			Console.ReadKey();
		}

	}
}
