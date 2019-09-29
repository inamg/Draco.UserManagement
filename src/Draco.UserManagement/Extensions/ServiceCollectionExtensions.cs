using Draco.UserManagement.DataProvider;
using Draco.UserManagement.JsonDataProvider;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Draco.UserManagement.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUserManagementServices(this IServiceCollection services)
        {
            services
                .AddSingleton<IUserManager, UserManager>()
                .AddSingleton<IUserDataProvider, UsersDataProviderJson>();

            return services;
        }

        public static IServiceCollection AddUserManagementServices<T>(this IServiceCollection services) where T : class, IUserDataProvider
        {
            services
                .AddSingleton<IUserManager, UserManager>()
                .AddSingleton<IUserDataProvider, T>();

            return services;
        }
    }
}
