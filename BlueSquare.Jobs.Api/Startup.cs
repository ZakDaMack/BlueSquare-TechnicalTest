using System.Reflection;
using BlueSquare.Infrastructure.Contexts;
using BlueSquare.Infrastructure.Options;
using BlueSquare.Infrastructure.Repositories;
using BlueSquare.Jobs.Application.Queries;
using BlueSquare.Jobs.Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;

namespace BlueSquare.Jobs.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; private set; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddOptions();

            services.Configure<MongoOptions>(Configuration.GetSection(MongoOptions.Position));

            services.AddDbContext<ClientDbContext>(opts =>
                opts.UseInMemoryDatabase("InMem"));

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IJobRepository), typeof(JobRepository));
            services.AddScoped<IMongoJobDbContext, MongoJobDbContext>();

            ConventionRegistry.Register("EnumStringConvention", new ConventionPack
            {
                new EnumRepresentationConvention(BsonType.String)
            }, t => true);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "JobService", Version = "v1" });
            });

            services.AddMediatR(typeof(GetAllJobsQuery).GetTypeInfo().Assembly);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "JobServices v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
