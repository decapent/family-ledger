using AutoMapper;

using Decapent.Ledger.Api.Dtos;
using Decapent.Ledger.Api.Dtos.Mappers;
using Decapent.Ledger.Domain.LedgerEvents;
using Decapent.Ledger.Domain.LedgerEvents.Queries;
using Decapent.Ledger.Infrastructure;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Nexus.Cqrs.Queries.Bus;
using Nexus.Cqrs.Queries.Handlers;

using ServiceStack.OrmLite;
using ServiceStack.OrmLite.SqlServer;

namespace Decapent.Ledger.Api
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
            services.AddControllers();

            // CORS Policies
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                    {
                        builder.AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowAnyOrigin();
                    });
            });

            // Database connection
            OrmLiteConfig.DialectProvider = new SqlServerOrmLiteDialectProvider();
            services.AddTransient(p => new OrmLiteConnectionFactory(this.Configuration.GetConnectionString("DefaultConnection")));

            // Automapper config
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<LedgerEvent, LedgerEventDto>()
                    .ForMember(dto => dto.LedgerImage, opt => opt.MapFrom<LedgerEventResolver>());    
            });

            services.AddSingleton(mapperConfig.CreateMapper());

            // Query bus and Query handler registration
            services.AddSingleton<IQueryBus, QueryBus>();
            services.AddTransient<IQueryHandler, AllLedgerEventQueryHandler>();

            // Registering repositories
            services.AddTransient<ILedgerEventRepository, SQLServerLedgerEventRepository>();
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
