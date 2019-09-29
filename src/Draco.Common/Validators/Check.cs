using System;
using System.Collections.Generic;
using System.Linq;

namespace Draco.Common.Validators
{
    public static class Check
    {
        public static void NotNull(object input, string name)
        {
            if (input == null)
            {
                throw new ArgumentNullException(name);
            }
        }

        public static void NotNullOrEmpty(string input, string name)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentNullException(name);
            }
        }

        public static void NotNullOrEmpty(IEnumerable<object> input, string name)
        {
            if (input == null)
            {
                throw new ArgumentNullException(name);
            }

            if (!input.Any())
            {
                throw new ArgumentException(name);
            }
        }
    }
}
