using MP.EnsekTest.Api.Exceptions;
using MP.EnsekTest.Data.Database;

namespace MP.EnsekTest.Api.Configuration
{
    internal static class DatabaseCreationExtensions
    {
        public static IApplicationBuilder CreateEnsekDatabase(this IApplicationBuilder app)
        {
            ArgumentNullException.ThrowIfNull(app, nameof(app));

            using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<EnsekContext>();
                EnsekDatabaseCreator.Initialize(context);
            }
            catch (Exception ex)
            {
                var message = $"Failed to create ensek database: {ex.Message}";
                var logger = services.GetRequiredService<ILogger<IApplicationBuilder>>();
                logger.LogError(ex, message);
                throw new ApiException(message, ex);
            }

            return app;
        }
    }
}
