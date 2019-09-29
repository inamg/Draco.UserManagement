using Draco.UserManagement.DataProvider;
using Draco.UserManagement.JsonDataProvider;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Draco.UserManagement.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUserManagementServices(this IServiceCollection services, string dataFile)
        {
            services
                .AddSingleton<IUserManager, UserManager>()
                .AddSingleton<IUserDataProvider, UsersDataProviderJson>();

            return services;
        }
    }
}
