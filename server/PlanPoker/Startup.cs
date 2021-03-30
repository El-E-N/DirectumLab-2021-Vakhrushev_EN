using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PlanPoker.Services;
using DataService.Models;
using DataService.Repositories;
using Microsoft.EntityFrameworkCore;

namespace PlanPoker
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<DiscussionService>();
            services.AddTransient<PlayerService>();
            services.AddTransient<RoomService>();
            services.AddTransient<VoteService>();

            services.AddTransient<IRepository<Discussion>, DiscussionMemoryRepository>();
            services.AddTransient<IRepository<Player>, PlayerMemoryRepository>();
            services.AddTransient<IRepository<Vote>, VoteMemoryRepository>();
            services.AddTransient<IRepository<Room>, RoomMemoryRepository>();

            services.AddDbContext<RoomContext>(opt =>
                                               opt.UseInMemoryDatabase("Room"));
            services.AddDbContext<PlayerContext>(opt =>
                                               opt.UseInMemoryDatabase("Player"));
            services.AddDbContext<DiscussionContext>(opt =>
                                               opt.UseInMemoryDatabase("Discussion"));
            services.AddDbContext<VoteContext>(opt =>
                                               opt.UseInMemoryDatabase("Vote"));
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
                endpoints.MapGet("/", async context =>
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
