using Microsoft.EntityFrameworkCore;
using todolist_api.Data;
using todolist_api.Repository;

namespace todolist_api
{
    public class Startup
    {
        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionstring = _configuration?.GetConnectionString("DefaultConnection");

            services.AddDbContext<DataContext>(opt => opt.UseMySql(connectionstring, ServerVersion.AutoDetect(connectionstring)));
            services.AddScoped<DataContext, DataContext>();
            services.AddTransient<ItemsRepository>();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API To Do List");
                });
            }

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
