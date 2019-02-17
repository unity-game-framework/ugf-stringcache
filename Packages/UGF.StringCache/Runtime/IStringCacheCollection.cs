using UGF.Instance.Runtime;

namespace UGF.StringCache.Runtime
{
    /// <summary>
    /// Provides the base interface to the string cache collection.
    /// </summary>
    public interface IStringCacheCollection<TIdentifier> : IInstanceCollection<TIdentifier, string>
    {
        /// <summary>
        /// Gets the unique identifier of the specified string.
        /// </summary>
        /// <param name="value">The value.</param>
        TIdentifier GetIdentifier(string value);
    }
}