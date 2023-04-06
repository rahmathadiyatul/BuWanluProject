using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using BuWanluWeb._2_Service;
using BuWanluWeb._3_Data;
using Swashbuckle.Swagger;

namespace BuWanluWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddCors();
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("https://localhost:3000")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                    });
            });

            services.AddControllers();
            DataDepedencyProfile.Register(Configuration, services);
            ServiceDepedencyProfile.Register(Configuration, services);
            services.AddSwaggerGen(c =>
            {
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First()); //This line
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(builder =>
                {
                    builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });

                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("./v1/swagger.json", "My API V1");
                });

                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
                app.UseRouting();

                app.UseEndpoints(endpoints =>
                    endpoints.MapControllers());
            }
        }
    } 
