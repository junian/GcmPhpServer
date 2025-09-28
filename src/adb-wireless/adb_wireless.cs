#!/usr/bin/env dotnet run

#:package Zeroconf@3.7.*

using Zeroconf;

const string AdbWirelessService = "_adb-tls-connect._tcp.local.";

var results = await
        ZeroconfResolver.ResolveAsync(AdbWirelessService);

if (results.Count <= 0)
{
    Console.WriteLine("No ADB Wireless device found");
    return;
}

Console.WriteLine($"{results.Count} ADB Wireless device(s) found");

var index = 1;
foreach (var r in results)
{
    if (r.Services == null)
        continue;

    foreach (var s in r.Services)
        foreach(var ip in r.IPAddresses)
            Console.WriteLine($"[{index++}] {r.DisplayName} {ip}:{s.Value.Port}");
}
