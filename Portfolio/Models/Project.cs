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

            var request = new RestRequest("users/kbordon/starred", Method.GET);
            request.AddHeader("Accept", "application/vnd.github.v3.full+json");
            request.AddHeader("User-Agent", "");

            // For PASSWORD authentication:
            // client.Authenticator = new HttpBasicAuthenticator(EnvironmentVariables.UserAgent, EnvironmentVariables.Key);

            // For TOKEN authentication: uncomment this, and reference variable from enviroment key.
            //request.AddHeader("Authorization", "token " + EnvironmentVariables.Key);

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

        public static string DisplayDate(string date){
            string displayStr = DateTime.Parse(date).ToString("MMM d, yyyy (h:mm t)");
            return displayStr;
        }
    }


}
