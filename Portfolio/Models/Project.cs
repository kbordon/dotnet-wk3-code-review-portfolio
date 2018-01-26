using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Portfolio.Models
{
    public class Project
    {
        
        public string Name { get; set; }
        public string Html_Url { get; set; }
        public string Description { get; set; }
        public string Created_At { get; set; }
        public string Pushed_At { get; set; }
        public string Language { get; set; }

        public static List<Project> GetStarred()
        {
            var client = new RestClient("https://api.github.com");
            var request = new RestRequest("user/starred", Method.GET);
            request.AddHeader("Accept", "application/vnd.github.v3.full+json");
            request.AddHeader("User-Agent", EnvironmentVariables.UserAgent);

            // If using token, uncomment this and reference variable from enviroment key.
            request.AddHeader("Authorization", EnvironmentVariables.Token);

            // If using basic password, and username authentication, comment out line 30, and use line below.
            client.Authenticator = new HttpBasicAuthenticator(EnvironmentVariables.UserAgent, EnvironmentVariables.Password);
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(response.Content);
            var projectList = JsonConvert.DeserializeObject<List<Project>>(jsonResponse[0].ToString());

            return projectList;
        }
    }


}
