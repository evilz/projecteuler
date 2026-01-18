using Microsoft.Extensions.Hosting;
using Projecteuler.Components;
using RazorConsole.Core;

var builder = Host.CreateApplicationBuilder(args);

builder.UseRazorConsole<App>();

await builder.Build().RunAsync();
