using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit;

namespace ConsoleApplication
{
    public class Startup
    {
         public void ConfigureServices(IServiceCollection services)
         {
            services.AddAuthentication();
         }

         public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
         {
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();
            app.UseJwtBearerAuthentication(new JwtBearerOptions()
            {
                //TODO: Replace XXXX with valid data
                AuthenticationScheme = "XXXX",
                Audience = "XXXX",
                Authority = "XXXX",
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                RequireHttpsMetadata=false
            });
         }
    }


    public class TestTest
    {
        [Fact]
        public async Task Blupp()
        {
            var builder  = new WebHostBuilder()
            .UseStartup<Startup>();
            var server = new TestServer(builder);
            var client = server.CreateClient();
            //TODO: Insert valid bearer key
            client.DefaultRequestHeaders.Add("Authorization", new [] {"Bearer XXXX"});
            await Task.WhenAll(new [] {client.GetAsync("/"),client.GetAsync("/"),client.GetAsync("/")});
        }
    }
}
