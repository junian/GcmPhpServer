#!/usr/bin/env dotnet run

#:sdk Microsoft.NET.Sdk.Web
#:package Microsoft.AspNetCore.OpenApi@10.*-*

var builder = WebApplication.CreateBuilder();

builder.Services.AddOpenApi();

var app = builder.Build();

app.MapGet("/", () => DateTimeOffset.Now.ToString());
app.Run();
