using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Ejercicio8
{
    public class ConfigureSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        private OpenApiInfo CreateVersionInfo(ApiVersionDescription description)
        {
            var info = new OpenApiInfo()
            {
                Title = "Open-Bootcamp | .NET | Excercise 8",
                Version = description.ApiVersion.ToString(),
                Description = "Excercise 8 for .NET Course",
                Contact = new OpenApiContact()
                {
                    Email = "santiago@gmail.com",
                    Name = "Santiago Torres"
                }
            };

            if (description.IsDeprecated)
            {
                info.Description += "This API version has been deprecated";
            }

            return info;
        }

        public void Configure(string name, SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
            }
        }

        public void Configure(SwaggerGenOptions options)
        {
            Configure(options);
        }
    }
}
