using FastFood.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FastFood.WebApi.Extensions
{
    public static class DataExtensions
    {
        /// <summary>
        /// Automatically updated database based on latest migration
        /// </summary>
        /// <param name="app"></param>
        public static void ApplyMigration(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            db.Database.Migrate();
        }
    }
}
