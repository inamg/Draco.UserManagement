using Draco.Common.Validators;
using System;
using Xunit;

namespace Draco.UserManagement.Tests.Validators
{
    //In real life will write many more tests
    public class CheckTests
    {
        [Fact]
        public void NotNull_WhenInputIsNull_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Check.NotNull(null, "arg"));
        }

        [Fact]
        public void NotNullOrEmpty_WhenInputIsEmpty_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Check.NotNullOrEmpty(string.Empty, "arg"));
        }

        [Fact]
        public void NotNull_WhenInputIsNull_ShouldNotThrowArgumentNullException()
        {
            Check.NotNull(new Guid(), "arg");
        }

        [Fact]
        public void NotNullOrEmpty_WhenInputIsNotEmpty_ShouldNOtThrowArgumentNullException()
        {
            Check.NotNullOrEmpty("hello world", "arg");
        }
    }
}
