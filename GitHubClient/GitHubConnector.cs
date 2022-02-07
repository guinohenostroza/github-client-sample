using System;
using RestSharp;
using Newtonsoft.Json;

using GitHubClient.Types;

namespace GitHubClient
{
    public class GitHubConnector
    {
        private IRestClient _restClient { get; set; }

        public GitHubConnector(): this(new RestClient()) {}

        public GitHubConnector(IRestClient client)
        {
            this._restClient = client;
            this._restClient.BaseUrl = new Uri("https://api.github.com/");
        }

        private IRestResponse getGitHubResponse(string username)
        {
            var request = new RestRequest("users/{username}", Method.GET);
            request.AddUrlSegment("username", username);

            return _restClient.Execute(request);
        }

        public UserInformation GetUserInformation(string username)
        {
            var gitHubResponse = getGitHubResponse(username);
            return JsonConvert.DeserializeObject<UserInformation>(gitHubResponse.Content);
        }

        public Boolean GitHubConnectorBAD(IRestClient client)
        {
            this._restClient = client;
            this._restClient = client;
            this._restClient = client;
            this._restClient = client;
            this._restClient = client;
            this._restClient = client;
            this._restClient = client;
            this._restClient = client;
            this._restClient = client;
            this._restClient = client;
            this._restClient = client;
            this._restClient = client;
            this._restClient = client;
            if(true)
            {
               this._restClient = client;
               this._restClient = client;
               this._restClient = client;
            }

            this._restClient.BaseUrl = new Uri("https://api.github.com/");
            return true;
        }

    }
}
