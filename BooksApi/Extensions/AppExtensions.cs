using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace BooksApi.Extensions
{
    public static class AppExtensions
    {
        public static void UseSwaggerExtension(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            app.UseSwagger();
            app.UseSwaggerUI(
              options =>
              {
                  //Build a swagger endpoint for each discovered API version
                  foreach (var description in provider.ApiVersionDescriptions)
                  {
                      options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                  }
              });
        }
        //public static void UseErrorHandlingMiddleware(this IApplicationBuilder app)
        //{
        //    app.UseMiddleware<ErrorHandlerMiddleware>();
        //}
    }
}
