using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Decapent.Ledger.Api.Dtos;
using Decapent.Ledger.Domain.LedgerEvents;
using Decapent.Ledger.Domain.LedgerEvents.Queries;
using Decapent.Ledger.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Nexus.Cqrs.Queries.Bus;
using Nexus.Cqrs.Queries.Handlers;

namespace Decapent.Ledger.Api
{
    public class Startup
    {
        readonly string AllowAllCORSPolicy = "AllowAllCORSPolicy";


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                    {
                        builder.AllowAnyHeader()
                                             .AllowAnyMethod()
                                             .AllowAnyOrigin()
                                             .AllowAnyHeader();
                    });
            });

            // Automapper config
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<LedgerEvent, LedgerEventDto>();
            });

            services.AddSingleton(mapperConfig.CreateMapper());

            // Query bus and Query handler registration
            services.AddSingleton<IQueryBus, QueryBus>();
            services.AddTransient<IQueryHandler, AllLedgerEventQueryHandler>();

            services.AddTransient<ILedgerEventRepository, MongoDBLedgerEventRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseCors();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
