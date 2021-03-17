using System;
using System.Net.Http;//adding for good measure, kept b/c required
using System.Net.Http.Headers;
using System.Threading.Tasks;//so compiler recogizes "Task" type
using System.Runtime.Serialization.Json; //$ dotnet add package System.Text.Json
using System.Text.Json; //add this with $ dotnet add package System.Text.Json
using System.Collections.Generic;

namespace WebAPIClient
{
    class Program
    {

        private static readonly HttpClient client = new HttpClient();
        
        public static async Task Main(string[] args)
        {
            var repositories = await ProcessRepositories();

            foreach(var repo in repositories)
            {
            Console.WriteLine(repo.Name);
            Console.WriteLine(repo.Description);
            Console.WriteLine(repo.GitHubHomeUrl);
            Console.WriteLine(repo.Homepage);
            Console.WriteLine(repo.Watchers);
            Console.WriteLine(repo.LastPush);
            Console.WriteLine();
            }
        }

        private static async Task<List<Repository>> ProcessRepositories() 
        {
          client.DefaultRequestHeaders.Accept.Clear();                                                //these first few lines set up the http client
          client.DefaultRequestHeaders.Accept.Add( 
              new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));                  //configured to accept github json responses
          client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");  //adds user agent header
          //the serializer uses a stream, not a string, as its source
          var streamTask = client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
          var repositories = await JsonSerializer.DeserializeAsync<List<Repository>>(await streamTask);  
          return repositories;

        }



    }
}
