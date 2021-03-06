using AutoMapper;
using Dice;
using GehennaApi.Models;
using Gehenna.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gehenna.Business.Services;
using Gehenna.Interfaces.Services;

namespace GehennaApi
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

            IMapper mapper = ConfigureMappings();

            services.AddSingleton(mapper);
            services.AddTransient<IDiceService, DiceService>();
        }

        private static IMapper ConfigureMappings()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RollResult, Gehenna.Models.GehennaRollResult>();
                cfg.CreateMap<Gehenna.Models.GehennaRollResult, Models.Dice.GehennaRollResult>();
                cfg.CreateMap<DieResult, Gehenna.Models.GehennaDieResult>();
                cfg.CreateMap<Gehenna.Models.GehennaDieResult, Models.Dice.GehennaDieResult>();
            });

            var mapper = config.CreateMapper();
            return mapper;
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
