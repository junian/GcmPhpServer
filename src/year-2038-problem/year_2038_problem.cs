#!/usr/bin/env dotnet run

#:package Humanizer@2.14.1

using Humanizer;

var year2038Problem = DateTimeOffset.Parse("2038-01-19T03:14:08+00:00");
var timeUntil2038Problem = year2038Problem - DateTimeOffset.Now;

Console.WriteLine($"It is {timeUntil2038Problem.Humanize()} until the Year 2038 Problem.");
