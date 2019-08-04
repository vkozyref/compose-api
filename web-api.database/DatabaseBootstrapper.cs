using System;
using Microsoft.Extensions.DependencyInjection;

namespace web_api.database
{
    public static class DatabaseBootstrapper
    {
        public static void Register(IServiceCollection services)
        {
            services.AddEntityFrameworkNpgsql()
               .AddDbContext<DatabaseContext>();
        }
    }
}
