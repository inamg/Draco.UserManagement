using System;
using Xunit;
using NSubstitute;
using Draco.UserManagement.DataProvider;
using System.Collections.Generic;
using Draco.UserManagement.DataProvider.Models;
using System.Linq;

namespace Draco.UserManagement.Tests
{
    public class UserManagerTests
    {
        [Fact]
        public void UserManager_WhenDataProviderIsNull_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new UserManager(null));
        }

        [Fact]
        public void GetUsers_WhenDataProviderIsValid_ShouldReturnUsers()
        {
            //Arrange
            var userDataProvider = Substitute.For<IUserDataProvider>();
            var userManager = new UserManager(userDataProvider);
            userDataProvider.Users.Returns(new List<User>());

            //Act
            var users = userManager.GetUsers();

            //Assert
            Assert.NotNull(users);
        }

        [Fact]
        public void GetUsers_WhenDataProviderHasNoData_ShouldReturnNoUsers()
        {
            //Arrange
            var userDataProvider = Substitute.For<IUserDataProvider>();
            var userManager = new UserManager(userDataProvider);
            userDataProvider.Users.Returns(new List<User>());

            //Act
            var users = userManager.GetUsers();

            //Assert
            Assert.NotNull(users);
            Assert.Equal(0, users.Count);
        }

        [Fact]
        public void GetUsers_WhenDataProviderHasData_ShouldReturnCorrectNoOfUsers()
        {
            //Arrange
            var userList = new List<User>
            {
                new User
                {
                    FirstName="Inam",
                    LastName="Gull",
                    Age=34,
                    Gender=Gender.M,
                    Id=1
                },
                new User
                {
                    FirstName="John",
                    LastName="Dep",
                    Age=40,
                    Gender=Gender.M,
                    Id=2
                }
            };
            var userDataProvider = Substitute.For<IUserDataProvider>();
            userDataProvider.Users.Returns(userList);
            var userManager = new UserManager(userDataProvider);

            //Act
            var users = userManager.GetUsers();

            //Assert
            Assert.NotNull(users);
            Assert.Equal(2, users.Count);
        }

        [Theory]
        [InlineData(1, "Inam", "Gull", 34, Gender.M)]
        [InlineData(2, "John", "Gull", 35, Gender.F)]
        [InlineData(3, "Adam", "Gull", 36, Gender.T)]
        [InlineData(4, "Jack", "Gull", 37, Gender.Y)]
        [InlineData(5, "Bill", "Gull", 38, Gender.O)]
        public void GetUsers_WhenDataProviderHasData_ShouldReturnCorrectUserData(int id, string first, string last, int age, Gender gender)
        {
            //Arrange
            var userList = new List<User>
            {
                new User
                {
                    FirstName=first,
                    LastName=last,
                    Age=age,
                    Gender=gender,
                    Id=id
                }
            };
            var userDataProvider = Substitute.For<IUserDataProvider>();
            userDataProvider.Users.Returns(userList);
            var userManager = new UserManager(userDataProvider);

            //Act
            var users = userManager.GetUsers(x => x.Id == id);

            //Assert
            Assert.NotNull(users);
            Assert.Equal(first, users.First().FirstName);
            Assert.Equal(last, users.First().LastName);
            Assert.Equal(age, users.First().Age);
            Assert.Equal(gender, users.First().Gender);
        }
    }
}
