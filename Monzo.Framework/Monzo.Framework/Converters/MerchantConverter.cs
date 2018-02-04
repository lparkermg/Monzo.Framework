namespace Monzo.Framework.Converters
{
    using System;
    using Monzo.Framework.Entities;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Custom Merchant JSON Converter.
    /// 
    /// Used so that the JSON serialiser is flexible on serialising a transaction response. 
    /// In the case that the consumer expands the merchant information, a Merchant object is returned
    /// however in the case where they do not expand the merchant information, the merchant ID (as a string) is returned.
    /// Because of this, we need the serialiser to be flexible to both eventualities.
    /// Note: in the case where no merchant information is assigned to a transaction, the api returns null.
    /// </summary>
    public class MerchantDataConverter : JsonConverter
    {
        /// <summary>
        /// Cans the convert.
        /// </summary>
        /// <returns><c>true</c>, if convert was caned, <c>false</c> otherwise.</returns>
        /// <param name="objectType">Object type.</param>
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Merchant));
        }

        /// <summary>
        /// Reads the JSON object.
        /// </summary>
        /// <returns>The json.</returns>
        /// <param name="reader">Reader.</param>
        /// <param name="objectType">Object type.</param>
        /// <param name="existingValue">Existing value.</param>
        /// <param name="serializer">Serializer.</param>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if (token.Type == JTokenType.Object)
            {
                return token.ToObject<Merchant>();
            }

            /*
             * The following is done because in the case were we cannot conver
             * into a Merchant object, the consumer has set the expand merchant option to false. 
             * In this case, the monzo api still returns back atleast the merchant id. 
             * Because of this, we create a new merchant and set the id so we still retain the information. 
             * In the case that there is not merchant information returned, this will simply be an empty object.
             */
            return new Merchant() { ID = token.ToString() };
        }

        /// <summary>
        /// Writes the json.
        /// </summary>
        /// <param name="writer">Writer.</param>
        /// <param name="value">Value.</param>
        /// <param name="serializer">Serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}