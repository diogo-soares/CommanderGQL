using CommanderGQL.Data;
using CommanderGQL.GraphQl;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GraphQL.Server.Ui.Voyager;
using CommanderGQL.GraphQl.Platforms;
using CommanderGQL.GraphQl.Commands;

namespace CommanderGQL
{
    public class Startup
    {
        private readonly IConfiguration Configuration;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPooledDbContextFactory<AppDbContext>(opt => opt.UseSqlServer
            (Configuration.GetConnectionString("CommandConStr")));

            services
              .AddGraphQLServer()
              .AddQueryType<Query>()
              .AddType<PlatformTypes>()
              .AddType<CommandsType>()
              .AddProjections()
              .AddFiltering()
              .AddSorting();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
               endpoints.MapGraphQL();
            });
            
             app.UseGraphQLVoyager(new GraphQLVoyagerOptions
            {
               GraphQLEndPoint = "/graphql",
               Path = "/graphql-voyager"
            });
        }
    }
}
