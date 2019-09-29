using System;
using System.Collections.Generic;
using System.Linq;
using Draco.Common.Validators;
using Draco.UserManagement.DataProvider;
using Draco.UserManagement.DataProvider.Models;

namespace Draco.UserManagement
{
    public class UserManager : IUserManager
    {
        private readonly IList<User> _users;

        public UserManager(IUserDataProvider dataProvider)
        {
            Check.NotNull(dataProvider?.Users, nameof(dataProvider));

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
