using DataService.Models;
using DataService.Models.Contexts;
using DataService.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PlanPoker.Services;

namespace PlanPoker
{
    /// <summary>
    /// Конфигурация программы.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Конструктор с присваиванием конфигурации.
        /// </summary>
        /// <param name="configuration">Конфигурация.</param>
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        /// <summary>
        /// Конфигурация.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Добавление сервисов для конфигурации.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<RoomContext>(opt =>
                                               opt.UseInMemoryDatabase("RoomDb"));
            services.AddDbContext<PlayerContext>(opt =>
                                               opt.UseInMemoryDatabase("PlayerDb"));
            services.AddDbContext<DiscussionContext>(opt =>
                                                opt.UseInMemoryDatabase("DiscussionDb"));
            services.AddDbContext<VoteContext>(opt =>
                                               opt.UseInMemoryDatabase("VoteDb"));
            services.AddDbContext<CardContext>(opt =>
                                               opt.UseInMemoryDatabase("VoteDb"));

            services.AddTransient<DiscussionMemoryRepository>();
            services.AddTransient<PlayerMemoryRepository>();
            services.AddTransient<VoteMemoryRepository>();
            services.AddTransient<RoomMemoryRepository>();
            services.AddTransient<CardMemoryRepository>();

            services.AddTransient<DiscussionService>();
            services.AddTransient<PlayerService>();
            services.AddTransient<RoomService>();
            services.AddTransient<VoteService>();
            services.AddTransient<CardService>();

            services.AddEntityFrameworkInMemoryDatabase();
        }

        /// <summary>
        /// Основная конфигурация.
        /// </summary>
        /// <param name="app">Объект IApplicationBuilder.</param>
        /// <param name="env">Объект для hostа.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
               app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(builder => builder.AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin()
            );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet(
                    "/", 
                    async context =>
                {
                    await context.Response.WriteAsync($"Application Name: {env.ApplicationName}");
                });
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
