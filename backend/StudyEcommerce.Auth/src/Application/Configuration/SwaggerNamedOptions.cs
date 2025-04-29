using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Application.Configuration;

    public class SwaggerNamedOptions(IApiVersionDescriptionProvider apiVersion) : IConfigureNamedOptions<SwaggerGenOptions>
    {
        public void Configure(string? name, SwaggerGenOptions options)
            => Configure(options);

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in apiVersion.ApiVersionDescriptions)
                options.SwaggerDoc(description.GroupName, CreateVersionApiInfo(description));
        }

        private OpenApiInfo CreateVersionApiInfo(ApiVersionDescription descripiton)
        {
            return new OpenApiInfo()
            {
                Title = Constants.ApiName,
                Version = descripiton.ApiVersion.ToString(),
                Description = Constants.ApiDescription
            };
        }
    }
