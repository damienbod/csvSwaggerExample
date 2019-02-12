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

            var all = await clientCsvWebApiSwagger.GetAllAsync();

            Console.WriteLine($"amount of jobs: {all.Count}");

            Console.WriteLine($"Create job: Id = 2340");

            var job = await clientCsvWebApiSwagger.PostAsync(new Job
            {
                Id = 2340,
                Description = "created using the NSwag generated code",
                Level = "amazing",
                Requirements = "Json nugetg package",
                Title = "NSwag generate"
            });

            all = await clientCsvWebApiSwagger.GetAllAsync();

            Console.WriteLine($"amount of jobs: {all.Count}");
            Console.ReadLine();

        }
    }
}
