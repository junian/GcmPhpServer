#!/usr/bin/env dotnet run

#:sdk Microsoft.NET.Sdk.Web
#:package Yarp.ReverseProxy@*

using Yarp.ReverseProxy.Configuration;

var builder = WebApplication.CreateBuilder(args);

var clusterId = Guid.NewGuid().ToString();

builder.Services.AddReverseProxy()
    .LoadFromMemory(
        [
            new RouteConfig
            {
                RouteId = Guid.NewGuid().ToString(),
                ClusterId = clusterId,
                Match = new RouteMatch { Path = "{**catch-all}" },
                Transforms =
                [
                    // Forward *all* request headers as-is
                    new Dictionary<string, string>
                    {
                        { "RequestHeadersCopy", "true" }
                    }
                ]
            }
        ],
        [
            new ClusterConfig
            {
                ClusterId = clusterId,
                Destinations = new Dictionary<string, DestinationConfig>(StringComparer.OrdinalIgnoreCase)
                {
                    ["upstream-api"] = new DestinationConfig
                    {
                        Address = "http://localhost:5101"
                    }
                }
            }
        ]
    );

var app = builder.Build();

app.Urls.Clear();
app.Urls.Add("http://0.0.0.0:6101");

app.MapReverseProxy();

app.Run();
