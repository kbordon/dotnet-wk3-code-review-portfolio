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
            // For personal use only.
            // var request = new RestRequest("user/starred", Method.GET);

            // To get a general listing of starred projects for the user specified in the UserAgent property.
            var request = new RestRequest("users/" + EnvironmentVariables.UserAgent + "/starred", Method.GET);
            request.AddHeader("Accept", "application/vnd.github.v3.full+json");
            request.AddHeader("User-Agent", EnvironmentVariables.UserAgent);

            // If using token, uncomment this and reference variable from enviroment key.
            //request.AddHeader("Authorization", EnvironmentVariables.Token);

            // If using basic password, and username authentication, make sure the line above is commented out, and use line below.
            client.Authenticator = new HttpBasicAuthenticator(EnvironmentVariables.UserAgent, EnvironmentVariables.Password);

            var response = new RestResponse();

            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();

            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(response.Content);
            List<Project> projectList = JsonConvert.DeserializeObject<List<Project>>(jsonResponse.ToString());
            return projectList;
        }

        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response => {
                tcs.SetResult(response);
            });

            return tcs.Task;
        }
    }


}
