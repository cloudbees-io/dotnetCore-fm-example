using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Io.Rollout.Rox.Core.Entities;
using Io.Rollout.Rox.Server;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Demo
{
    public class Program
    {
        static IRoxContainer flagsContainer = new FeatureManagement.Container();
        public static FeatureManagement.Container FlagsContainer { get { return (FeatureManagement.Container) flagsContainer; }}

        public static async Task Main(string[] args)
        {
            Rox.Register(Program.FlagsContainer);
            // TODO: insert your SDK key from https://cloudbees.io/ below.
            var sdkKey = "<YOUR-SDK-KEY>";
            await Rox.Setup(sdkKey);
            CreateHostBuilder(args).Build().Run();
            await Rox.Shutdown();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
