using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Net;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace ToDoLister
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                    .UseKestrel(options => 
                    {
                        options.Listen(IPAddress.Loopback, 5000, listenOptions => {
                            listenOptions.Protocols = HttpProtocols.Http2;
                            listenOptions.UseHttps();
                        });
                    });
                    
                });
    }
}
