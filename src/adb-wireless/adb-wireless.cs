#!/usr/bin/env dotnet run

#:package Zeroconf@3.7.*

using Zeroconf;

const string AdbWirelessService = "_adb-tls-connect._tcp.local.";

var results = await
        ZeroconfResolver.ResolveAsync(AdbWirelessService);

if (results.Count <= 0)
{
    Console.WriteLine("No Wireless ADB device found");
    return;
}

Console.WriteLine($"{results.Count} Wireless ADB device(s) found");

var index = 1;
foreach (var r in results)
{
    if (r.Services == null)
        continue;

    foreach (var s in r.Services)
    {
        Console.WriteLine($"[{index++}] {r.DisplayName} {r.IPAddress}:{s.Value.Port}");
    }
}
