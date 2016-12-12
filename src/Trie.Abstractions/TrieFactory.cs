using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trie.Abstractions
{
    public class TrieFactory : ITrieFactory
    {
        public ValueTask<ITrie> LoadFromDataProvider(IDataSetProvider provider)
        {
            throw new NotImplementedException();
        }
    }
}
