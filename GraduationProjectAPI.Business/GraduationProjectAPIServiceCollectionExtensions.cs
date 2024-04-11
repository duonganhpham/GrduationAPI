using GraduationProjectAPI.Business.RoomBusiness;
using GraduationProjectAPI.Business.RoomImageBusiness;
using GraduationProjectAPI.Business.UserBusiness;
using GraduationProjectAPI.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SERP.Framework.Common.Configs;
using SERP.Framework.Services.Cache;

namespace GraduationProjectAPI.Business
{
    public static class SampleServiceCollectionExtensions
    {
        public static IServiceCollection RegisterSampleServiceComponents(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterCacheComponents(configuration);

            var dbSetings = configuration.GetSection(nameof(DBSettings)).Get<DBSettings>();
            services.AddDbContext<DataContext>(x => x.UseSqlServer(dbSetings.ConnectionString), ServiceLifetime.Transient);
			// dòng dưới này dùng cho PostgreSQL
			// services.AddDbContext<DataContext>(x => x.UseNpgsql(dbSetings.ConnectionString), ServiceLifetime.Transient);
			// Đăng ký các dịch vụ vào DI container
			services.AddTransient<IUserRepository, UserRepository>();
			services.AddTransient<IUserService, UserService>();
			services.AddTransient<IRoomRepository, RoomRepository>(); 
            services.AddTransient<IRoomService, RoomService>();
			services.AddTransient<IRoomImageRepository,RoomImageRepository>();
			return services;
        }
    }
}