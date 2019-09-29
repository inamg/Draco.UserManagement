using System;
using System.Collections.Generic;
using System.IO;
using Draco.Common.Validators;
using Draco.UserManagement.DataProvider;
using Draco.UserManagement.DataProvider.Models;
using Draco.UserManagement.JsonDataProvider.Exceptions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Draco.UserManagement.JsonDataProvider
{
    public class UsersDataProviderJson : IUserDataProvider
    {
        private readonly ILogger<UsersDataProviderJson> _logger;
        private string _jsonFile;
        public IList<User> Users { get; }

        public UsersDataProviderJson(ILogger<UsersDataProviderJson> logger, string jsonFile = "example_data.json")
        {
            Check.NotNull(logger, nameof(logger));
            Check.NotNullOrEmpty(jsonFile, nameof(jsonFile));

            _logger = logger;
            _jsonFile = jsonFile;

            try
            {
                using (StreamReader sr = new StreamReader(_jsonFile))
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    // We can validate json file here but i don't see any advantage
                    Users = new JsonSerializer().Deserialize<IList<User>>(reader);
                }
            }
            catch (JsonReaderException exp)
            {
                var msg = $"Invalid json Data : {exp.Message}";

                _logger.LogError(msg);

                throw new InvalidJsonException(msg);
            }
            catch (JsonSerializationException exp)
            {
                var msg = $"Invalid json Data : {exp.Message}";

                _logger.LogError(msg);

                throw new InvalidJsonException(msg);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);

                throw exp;
            }
        }
    }
}
