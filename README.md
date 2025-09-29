<div align="center">

<img src="https://raw.githubusercontent.com/junian/commons-media/refs/heads/master/svg/microsoft-dotnet-logo.svg" height="128px" />

# .NET Console Apps

A collection of .NET console apps and scripts

</div>

## About

This is a special repository to celebrate `dotnet run app.cs`, where you can just use a single C# file to run the script.

You need [.NET 10 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/10.0) installed.

Read example guide [here](https://www.junian.net/dev/dotnet-run-csharp-app/).

## Content

- [Hello, World!](./src/hello-world/)
- [Year 2038 Problem](./src/year-2038-problem/)
- [ASP.NET Server Time](./src/aspdotnet-server-time/)

## Executable PATH

If you're on macOS, Linux, or any Unix-like OS, you can set the `bin` folder in the path to directly execute the script.
For example:

```bash
export PATH="$HOME/dotnet-console-apps/bin:$PATH"
```

## License

[MIT](./LICENSE).
