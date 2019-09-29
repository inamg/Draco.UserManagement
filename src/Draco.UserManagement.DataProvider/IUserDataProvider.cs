using Draco.UserManagement.DataProvider.Models;
using System.Collections.Generic;

namespace Draco.UserManagement.DataProvider
{
    public interface IUserDataProvider
    {
        IList<User> Users { get; }
    }
}
