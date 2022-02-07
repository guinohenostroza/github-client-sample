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

        private void BugsSamples()
        {
            string select = "SELECT p.fname, p.lname, p.street1, p.street2, p.city, p.state, p.zip" +
                            "FROM person p" +  // Noncompliant; concatenates to: p.zipFROM
                            "WHERE p.id = @ID";  // Noncompliant; concatenates to: pWHERE

            int target = -5;
            int num = 3;

            target =- num;  // Noncompliant; target = -3. Is that really what's meant?
            target =+ num; // Noncompliant; target = 3

            bool a = false;
            bool b = false;

            if (!a || b) // Noncompliant; "!a" is always "true", "b" is never evaluated
            {
               // always executed
            }
            else
            {
               // never executed
            }







        }

    }
}
