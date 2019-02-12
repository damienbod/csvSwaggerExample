using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApiClient
{
    class Program
    {
        public static void Main(string[] args) => MainAsync().GetAwaiter().GetResult();

        static async Task MainAsync()
        {
            Console.WriteLine("begin...");

            HttpClient httpClient = new HttpClient();

            var clientCsvWebApiSwagger = new ClientCsvWebApiSwagger(
                "https://localhost:44354/", httpClient);

            // Gets all to-dos from the API
            var all = await clientCsvWebApiSwagger.GetAllAsync();

            Console.ReadLine();

        }
    }
}
