using System.IO.Compression;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebMarkupMin.AspNetCore3;

namespace Recepdmr.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<BrotliCompressionProvider>();
                options.Providers.Add<GzipCompressionProvider>();
                options.MimeTypes =
                    ResponseCompressionDefaults.MimeTypes.Concat(
                        new[] { "image/svg+xml" });
            });
            services.Configure<BrotliCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Fastest;
            });

            services.AddWebMarkupMin(
                options =>
                {
                    options.AllowMinificationInDevelopmentEnvironment = true;
                    options.AllowCompressionInDevelopmentEnvironment = true;
                })
                .AddHtmlMinification(
                    options =>
                    {
                        options.MinificationSettings.RemoveRedundantAttributes = true;
                        options.MinificationSettings.RemoveHttpProtocolFromAttributes = true;
                        options.MinificationSettings.RemoveHttpsProtocolFromAttributes = true;
                    })
                .AddHttpCompression();
        }



        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();
            app.UseResponseCompression();
            app.UseWebMarkupMin();

            app.UseRouting();
            app.UseHsts();
            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
