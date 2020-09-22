using System;
using AutoMapper;
using DotNetCore_REST.Data;
using DotNetCore_REST.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;

namespace DotNetCore_REST
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
      // DB Context
      services.AddDbContext<PersonContext>(options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

      // JSON serializer
      services.AddControllers().AddNewtonsoftJson(
        s => s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver()
      );

      // Automapper for DTO(Data Transfer Object)
      services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

      // Scoped Object for repository 
      services.AddScoped<IPersonRepo, PersonRepo>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      // middlewares
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
