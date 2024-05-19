using CV_Manager.Middleware;

namespace CV_Manager.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder AddGlobalErrorHandler(this IApplicationBuilder applicationBuilder)
         => applicationBuilder.UseMiddleware<GlobalErrorHandlingMiddleware>();
    }
}
