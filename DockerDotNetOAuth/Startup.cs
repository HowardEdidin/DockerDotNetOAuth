using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DockerDotNetOAuth
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
            services.AddCors();
            services.AddMvc();
            services.AddAuthentication(opt =>
                {
                    opt.DefaultScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
                    opt.DefaultAuthenticateScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
                })
                .AddIdentityServerAuthentication(
                    opt =>
                    {
                        opt.Authority = "http://identityserver";
                        opt.RequireHttpsMetadata = false;
                        opt.ApiName = "api1";
                    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(
                builder => builder
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithOrigins("http://157.56.176.142:32773"));

            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseAuthentication();
            app.UseMvc();
        }
    }
}