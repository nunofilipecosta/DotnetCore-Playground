﻿using Newtonsoft.Json;
using System;

namespace PatternsAndPractices.Adapter.ThirdPartyApi
{
    public class GenderConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Gender gender = (Gender)value;

            if (writer != null)
                writer.WriteValue(gender.ToString());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader == null)
            {
                throw new ArgumentNullException(nameof(reader));
            }

            var enumString = (string)reader.Value;

            if (enumString == "n/a") return Gender.NotApplicable;

            return Enum.Parse(typeof(Gender), enumString, true);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }
    }

}
