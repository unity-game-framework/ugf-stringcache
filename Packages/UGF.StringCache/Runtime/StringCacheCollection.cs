using System.Collections.Generic;
using UGF.Instance.Runtime;

namespace UGF.StringCache.Runtime
{
    /// <summary>
    /// The generic string cache collection to generate and store strings by unique identifiers.
    /// </summary>
    public class StringCacheCollection<TIdentifier> : InstanceCollectionCached<TIdentifier, string>, IStringCacheCollection<TIdentifier>
    {
        private readonly Dictionary<string, TIdentifier> m_identifiers = new Dictionary<string, TIdentifier>();

        /// <summary>
        /// Creates the collection with the specified identifier generator.
        /// </summary>
        /// <param name="generator">The identifier generator.</param>
        public StringCacheCollection(IInstanceIdentifierGenerator<TIdentifier> generator) : base(generator)
        {
        }

        public override TIdentifier Add(string instance)
        {
            var identifier = base.Add(instance);

            m_identifiers.Add(instance, identifier);
            
            return identifier;
        }

        public override bool Remove(TIdentifier identifier)
        {
            if (TryGetInstance(identifier, out var instance) && base.Remove(identifier))
            {
                m_identifiers.Remove(instance);
                
                return true;
            }

            return false;
        }

        public override void Clear()
        {
            base.Clear();
            
            m_identifiers.Clear();
        }

        public TIdentifier GetIdentifier(string value)
        {
            if (!m_identifiers.TryGetValue(value, out var identifier))
            {
                identifier = Add(value);
            }

            return identifier;
        }
    }
}