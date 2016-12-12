using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trie.Abstractions
{
    public interface ITrie
    {
        ValueTask<QueryResult> GetWords(Span<byte> prefix, byte top);
    }
}
