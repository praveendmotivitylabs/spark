using System.Collections.Generic;
using Spark.Core;
using Spark.Engine.Core;

namespace Spark.Engine.Store.Interfaces
{
    public interface IFhirStore : IExtensibleObject<IFhirStoreExtension>, IGenerator
    {
        void Add(Entry entry);
        Entry Get(IKey key);
        IList<Entry> Get(IEnumerable<string> localIdentifiers, string sortby);
    }
}