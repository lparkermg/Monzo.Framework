namespace Monzo.Framework.Contracts
{
    /// <summary>
    /// Encapsulates logic for parsing and getting JSON objects
    /// </summary>
    public interface IJSONService
    {
        /// <summary>
        /// Parses the passed JSON into a object.
        /// </summary>
        /// <returns>the generated object.</returns>
        /// <param name="json">json to parse.</param>
        /// <typeparam name="T">The type of object to generate</typeparam>
        T Parse<T>(string json);

        /// <summary>
        /// Parse the passed object into a JSON object.
        /// </summary>
        /// <returns>the parsed JSON.</returns>
        /// <param name="obj">object to parse.</param>
        /// <typeparam name="T">The type of object to parse</typeparam>
        string Parse<T>(T obj);
    }
}