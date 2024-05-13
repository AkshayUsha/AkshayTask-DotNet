using AkshayTask.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
namespace AkshayTask
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Akshay - DotNET Task- Capital Placement\r\n", Version = "v1" });
            });
            services.AddSingleton((serviceProvider) =>
            {
                var cosmosClient = new CosmosClient("https://cosmos-db-akshay.documents.azure.com:443/", "uUkh2D9Xgnhd8F6IqLDJaldYpbV43SRLLNMTk6NDiSGRQnuYhBIKI37RWVU0XWysjPgli7QbvBtBACDbzjFh3w==");
                return cosmosClient;
            });

            services.AddTransient<IQuestionRepository, CosmosQuestionRepository>(provider =>
                new CosmosQuestionRepository(provider.GetRequiredService<CosmosClient>(), "mycosmodbakshay", "Employer"));

            services.AddTransient<IApplicationRepository, CosmosApplicationRepository>(provider =>
                new CosmosApplicationRepository(provider.GetRequiredService<CosmosClient>(), "ToDoList", "Items"));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            // Enable middleware to serve Swagger UI (HTML, JS, CSS, etc.)
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Questionnaire API V1");
            });


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
