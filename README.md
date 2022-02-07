# github-client-sample
![.NET Core](https://github.com/jersson/github-client-sample/workflows/GitHubClient%20Sample/badge.svg?branch=master)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=jersson_github-client-sample&metric=alert_status)](https://sonarcloud.io/dashboard?id=jersson_github-client-sample)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=jersson_github-client-sample&metric=coverage)](https://sonarcloud.io/dashboard?id=jersson_github-client-sample)

I've created this dotnetcore library as an example to show how to get github information. It's kinda one of my pet projects so please, be nice :innocent:

## Summary
- [what's the folder structure?](#whats-the-folder-structure)
- [what does the code do?](#what-does-the-code-do)
- [how to compile the code?](#how-to-compile-the-code)
- [how to run the code?](#how-to-run-the-code)
- [how to test the code?](#how-to-test-the-code)
- [about the sonar integration](#about-the-sonar-integration)

## what's the folder structure?
```
.
├── GitHubClient
│   ├── GitHubClient.csproj
│   ├── GitHubConnector.cs
│   └── types
│       ├── UserInformation.cs
│       └── UserInformationProperty.cs
├── GitHubClientTest
│   ├── GitHubClientTest.csproj
│   ├── GitHubConnectorTest.cs
│   └── types
│       ├── UserInformationPropertyTest.cs
│       └── UserInformationTest.cs
├── GitHubConsoleDemo
│   ├── GitHubConsoleDemo.csproj
│   └── Program.cs
├── README.md
└── github-client-sample.sln
```

## what does the code do?
I've created a connector to the [GitHub API](https://developer.github.com/v3/), I'm using the [RestSharp](http://restsharp.org/getting-started/#basic-usage) library for get the information I need to consume and the [Json.NET](https://www.newtonsoft.com/json) library to serialize it.

The `GitHubConnector` class contains all you need to get the required GitHub information.
```c#
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
}
``` 

## how to compile the code?
You can use the `dotnet build` command in the root folder
```
Build succeeded.
    0 Warning(s)
    0 Error(s)

Time Elapsed 00:00:01.31
```

## how to run the code?
This is a class library so you can run a console client I built, it's just an example and you can use the `dotnet run --project GitHubConsoleDemo` command in the root folder or the `dotnet run` command in the `GitHubConsoleDemo` folder:
```
Put your GitHub username: jersson
Hello jersson, this is your GitHub information:
* Login: jersson
* FullName: Jersson Dongo
* Company: @mckinsey
* Blog: http://jersson.net
* GitHubPage: https://github.com/jersson
* PublicRepos: 26
* CreationDate: 02/20/2012 01:07:28
* LastUpdate: 10/22/2021 14:29:46
* Twitter: @jersson
```

## how to test the code?
You can run the `dotnet test` command in the root folder or the test folder:
```
Starting test execution, please wait...
A total of 1 test files matched the specified pattern.

Passed!  - Failed:     0, Passed:     3, Skipped:     0, Total:     3, Duration: 445 ms
```

I'm using [**xUnit**](https://xunit.net/docs/getting-started/netcore/cmdline) for the test cases I've written and [**moq**](https://github.com/Moq/moq4/wiki/Quickstart) to mock the use of the `RestClient` object, this is a really [interesting post](https://softchris.github.io/pages/dotnet-moq.html) about moq. If you want to read about dependency injection, you can go to [this post](https://www.c-sharpcorner.com/UploadFile/85ed7a/dependency-injection-in-C-Sharp/).

## about the Sonar integration
The last thing I've added to this project is the feature to send the information to a Sonar server. This is kinda open source project so I'm using the free access to [SonarSource](https://sonarcloud.io/dashboard?id=jersson_github-client-sample) but you can make the commercial way or install it locally (I mean, in your cloud) 

You can check the [workflow file](.github/workflows/dotnet-core.yml) I've made using [GitHub Actions](https://github.com/features/actions), I thing it's easy to understand and of course, run it, but if you want to use it, don't forget to define at least these [GitHub Secrets](https://docs.github.com/en/actions/configuring-and-managing-workflows/creating-and-storing-encrypted-secrets):

- SONAR_HOST_URL
- SONAR_ORGANIZATION_KEY
- SONAR_PROJECT_KEY
- SONAR_TOKEN

jersson
