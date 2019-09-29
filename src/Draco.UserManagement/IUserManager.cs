using Draco.UserManagement.DataProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Draco.UserManagement
{
    public interface IUserManager
    {
        IReadOnlyList<User> GetUsers(Func<User, bool> filter = null, Func<IQueryable<User>, IOrderedQueryable<User>> orderBy = null);
    }
}
