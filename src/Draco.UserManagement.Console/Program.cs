using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Draco.UserManagement.Extensions;
using System;
using System.Linq;
using Draco.UserManagement.JsonDataProvider.Exceptions;
using Draco.UserManagement.DataProvider.Models;

namespace Draco.UserManagement.ConsoleApp
{
    class Program
    {
        private static ILogger<Program> _logger;
        private static IUserManager _userManager;

        static void Main(string[] args)
        {
            var serviceProvider = ConfigureServices();
            _logger = serviceProvider.GetService<ILogger<Program>>();

            try
            {
                _userManager = serviceProvider.GetRequiredService<IUserManager>();
                //Display Full name of users with id 42
                DisplayUserWithId(42);

                //Comma seperated list of users who are 23
                DisplayUsersWithAge(23);

                //No of genders per Age
                NumberOfGendersPerAge();
            }
            catch (InvalidJsonException exp)
            {
                Console.WriteLine("Provided Json file doesnt have correct data.Check logs for more details");
                _logger.LogError(exp.Message);
            }
            catch (Exception exp)
            {
                Console.WriteLine("Something went wrong.Check logs for more details");
                _logger.LogError(exp.Message);
            }
        }

        private static void DisplayUserWithId(int id)
        {
            var usersWithId = _userManager.GetUsers(x => x.Id == id);
            if (!usersWithId.Any())
            {
                Console.WriteLine($"There is no user with Id : {id}");
                return;
            }

            Console.WriteLine($"Following are the users with Id : {id}");
            foreach (var user in usersWithId)
            {
                Console.WriteLine($"{user.FirstName} {user.LastName}");
            }
        }

        private static void DisplayUsersWithAge(int age)
        {
            var usersWithAge = _userManager.GetUsers(x => x.Age == age);
            if (!usersWithAge.Any())
            {
                Console.WriteLine($"There is no user with age : {age}");
                return;
            }

            Console.WriteLine($"Users with age {age} are : {string.Join(",", usersWithAge.Select(x => x.FirstName))}");
        }

        private static void NumberOfGendersPerAge()
        {
            var groups = _userManager.GetUsers().GroupBy(x => x.Age).OrderBy(x => x.Key);
            foreach (var group in groups)
            {
                Console.WriteLine($"Age :{group.Key} Female:{group.Where(x => x.Gender == Gender.F).Count()}  Male :{group.Where(x => x.Gender == Gender.M).Count()}");
            }
        }

        private static IServiceProvider ConfigureServices()
        {
            //setup DI
            var serviceProvider = new ServiceCollection()
                                 .AddUserManagementServices("example_data.json")
                                 .AddLogging(configure => configure.AddConsole())
                                 .BuildServiceProvider();

            return serviceProvider;
        }
    }
}
