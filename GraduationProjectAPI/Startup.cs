using SERP.Framework.ApiUtils;
using SERP.Framework.LoggingConfiguration;
using System.Reflection;
using GraduationProjectAPI.Business;

namespace Graduation_Project_API
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            var builder = StartupHelpers.CreateDefaultConfigurationBuilder(env);
            builder.AddLogging(); // SERP.Framework.LoggingConfiguration - Add this line 

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.RegisterApiVersioningComponents();
            services.RegisterCommonServiceComponents(Configuration);
            services.RegisterSwaggerServiceComponents(Configuration, Assembly.GetExecutingAssembly());
            services.RegisterSampleServiceComponents(Configuration);



            // SERP.Framework.LoggingConfiguration - Add this line 

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            IHttpContextAccessor contextAccessor // SERP.Framework.LoggingConfiguration - Add this line 
            )
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseCommonConfig();
            app.UseSwaggerConfig(Configuration);
            app.UseFrameworkLogging(Configuration, contextAccessor);  // SERP.Framework.LoggingConfiguration - Add this line 


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
