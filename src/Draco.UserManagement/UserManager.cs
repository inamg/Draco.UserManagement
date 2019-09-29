using System;
using System.Collections.Generic;
using System.Linq;
using Draco.Common.Validators;
using Draco.UserManagement.DataProvider;
using Draco.UserManagement.DataProvider.Models;
using Microsoft.Extensions.Logging;

namespace Draco.UserManagement
{
    public class UserManager : IUserManager
    {
        private readonly IList<User> _users;
        private readonly ILogger<UserManager> _logger;

        public UserManager(IUserDataProvider dataProvider, ILogger<UserManager> logger)
        {
            Check.NotNull(dataProvider?.Users, nameof(dataProvider));
            Check.NotNull(logger, nameof(logger));
            _logger = logger;

            _logger.LogInformation("Users Loaded.");
            _users = dataProvider.Users;
        }

        public IReadOnlyList<User> GetUsers(Func<User, bool> filter = null,
                                            Func<IQueryable<User>, IOrderedQueryable<User>> orderBy = null)
        {
            IQueryable<User> query = _users.AsQueryable();

            if (filter != null)
            {
                query = query.Where(filter).AsQueryable();
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
    }
}
