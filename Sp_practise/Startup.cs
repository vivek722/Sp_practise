using SP.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Domain.Service.Service;
using SP.EF.Repositoy;
using Entity.FirebaseManagement;
using Microsoft.Extensions.DependencyInjection;

namespace Sp_practise
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public Startup(  IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            _configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDBContext>(options =>
                options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<EmployeeService>();
            services.AddTransient<IEmployeeRepository, Employeerepository>();
            services.AddTransient<IEmployeeService, EmployeeService>();

            string bucketName = "practice-bdcd1.appspot.com"; // Replace with your actual bucket name
            string firebaseStorageUrl = $"https://firebasestorage.googleapis.com/v0/b/{bucketName}/o/";

            services.AddSingleton( new FirebaseService(bucketName, firebaseStorageUrl));
            services.AddTransient<IFirebaseUploadImageService, FireBaseUploadImageService>();

            services.AddAutoMapper(typeof(Startup));

            services.AddControllers();
            services.AddSwaggerGen();
        }
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllerRoute(
               name: "default",
               pattern: "{controller=WeatherForecast}/{action=Get}");
            app.Run();
        }
    }
}
