using Draco.UserManagement.JsonDataProvider;
using Draco.UserManagement.JsonDataProvider.Exceptions;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using Xunit;

namespace Draco.UserManagement.Tests
{
    public class UserDataProviderJsonTests
    {
        [Fact]
        public void UsersDataProviderJson_WhenLoggerIsNull_ShouldThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => new UsersDataProviderJson(null));
        }

        [Fact]
        public void UsersDataProviderJson_WhenJsonFileIsEmpty_ShouldThrowException()
        {
            //Arrange
            var logger = NSubstitute.Substitute.For<ILogger<UsersDataProviderJson>>();

            //Act and Assert
            Assert.Throws<ArgumentNullException>(() => new UsersDataProviderJson(logger, string.Empty));
        }

        [Fact]
        public void UsersDataProviderJson_WhenJsonFileIsProvided_ShouldLoadProperData()
        {
            //Arrange
            var logger = NSubstitute.Substitute.For<ILogger<UsersDataProviderJson>>();

            //Act
            var provider = new UsersDataProviderJson(logger, "test_data.json");
            var users = provider.Users;

            //Assert
            Assert.NotNull(users);
            Assert.Equal(1, users.Count);
            Assert.Equal("Bill", users.First().FirstName);
            Assert.Equal("Bryson", users.First().LastName);
            Assert.Equal(23, users.First().Age);
        }

        [Fact]
        public void UsersDataProviderJson_WhenJsonFileIsInValid_ShouldThrowInvalidJsonException()
        {
            //Arrange
            var logger = NSubstitute.Substitute.For<ILogger<UsersDataProviderJson>>();

            //Act and Assert
            Assert.Throws<InvalidJsonException>(() => new UsersDataProviderJson(logger, "invalid_json.json"));
        }
    }
}
