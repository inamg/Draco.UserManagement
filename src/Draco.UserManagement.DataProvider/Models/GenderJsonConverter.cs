using Draco.UserManagement.DataProvider.Models;
using Newtonsoft.Json;
using System;

namespace Draco.UserManagement.DataProvider
{
    public class GenderJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Gender gender = (Gender)value;

            switch (gender)
            {
                case Gender.Male:
                    writer.WriteValue("M");
                    break;
                case Gender.Female:
                    writer.WriteValue("F");
                    break;
                case Gender.Trans:
                    writer.WriteValue("T");
                    break;
                case Gender.Y:
                    writer.WriteValue("Y");
                    break;
                case Gender.Other:
                    writer.WriteValue("O");
                    break;
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var enumString = (string)reader.Value;

            switch (enumString)
            {
                case "M":
                    return Gender.Male;
                case "F":
                    return Gender.Female;
                case "T":
                    return Gender.Trans;
                case "Y":
                    return Gender.Y;
                case "O":
                    return Gender.Other;
            }

            throw new Exception("Invalid Enum value");
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }
    }
}
