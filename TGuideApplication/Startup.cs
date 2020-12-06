
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TGuideApplication.Core.DbModels;
using TGuideApplication.Core.IMessageQueue;
using TGuideApplication.Core.IRepository;
using TGuideApplication.MessageQueue;
using TGuideApplication.Servicee.Services;

namespace TGuideApplication
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


            services.Configure<Settings>(o => { o.IConfigurationRoot = (IConfigurationRoot)Configuration; });
            services.AddScoped<IPersonInfoRepository, PersonInfoRepository>();
            services.AddScoped<ITGuidePublisherModelRepository, TGuidePublisherModelRepository>();
            services.AddScoped<IPublisher, TGuidePublisher>();
            services.AddControllers();
            // services.AddMassTransit(config =>
            //{
            //    config.UsingRabbitMq((ctx, cfg) =>
            //    {
            //        cfg.Host("amqps://nohtjnhs:ov2OEjCyIJuw09Oum-bmsed6Fx_DPGFm@jaguar.rmq.cloudamqp.com/nohtjnhs");
            //    });

            //});
            // services.AddMassTransitHostedService();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
