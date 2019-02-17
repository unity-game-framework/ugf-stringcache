using System;
using NUnit.Framework;
using UGF.Instance.Runtime.Generators;

namespace UGF.StringCache.Runtime.Tests
{
    public class TestStringCacheCollection
    {
        [Test]
        public void GetIdentifier()
        {
            var collection = new StringCacheCollection<int>(new InstanceIdentifierGeneratorInt32());
            int id0 = collection.GetIdentifier("name");
            int id1 = collection.GetIdentifier("name");
            int id2 = collection.GetIdentifier("name2");
            
            Assert.AreEqual(id0, id1);
            Assert.AreNotEqual(id0, id2);
        }

        [Test]
        public void GetValue()
        {
            var collection = new StringCacheCollection<int>(new InstanceIdentifierGeneratorInt32());
            int id0 = collection.GetIdentifier("name");
            bool result = collection.TryGetInstance(id0, out var value);
            
            Assert.IsTrue(result);
            Assert.NotNull(value);
            Assert.AreEqual("name", value);
        }
        
        [Test]
        public void WithGuidAsId()
        {
            var collection = new StringCacheCollection<Guid>(new InstanceIdentifierGeneratorGuid());
            var guid0 = collection.GetIdentifier("name");
            var guid1 = collection.GetIdentifier("name");
            var guid2 = collection.GetIdentifier("name2");
            bool result = collection.TryGetInstance(guid0, out var value);
                        
            Assert.IsTrue(result);
            Assert.AreEqual(guid0, guid1);
            Assert.AreNotEqual(guid0, guid2);
            Assert.NotNull(value);
            Assert.AreEqual("name", value);
        }
    }
}
