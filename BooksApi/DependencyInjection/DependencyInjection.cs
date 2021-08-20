using Books.BusinessService;
using Books.BusinessService.IBusinessService;
using Books.Common.AutoMapperProfiles;
using Books.DataAccess.DataContext;
using Books.DataAccess.Repositories;
using Books.DataAccess.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BooksApi.DependencyInjection
{
    public class DependencyInjection
    {
        private readonly IConfiguration Configuration;
        public DependencyInjection(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void InjectDependencies(IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DBConnection"));
            });
            services.AddAutoMapper(typeof(AutoMapperProfiles));
            services.AddScoped<IBooksRepository, BooksRepository>();
            services.AddScoped<IBooksService, BooksService>();            
        }
    }
}