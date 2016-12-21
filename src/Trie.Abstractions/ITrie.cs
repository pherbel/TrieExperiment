using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trie.Abstractions
{
    public interface ITrie: IDisposable
    {
        ValueTask<QueryResult> GetWords(/*Span<byte>*/ string  prefix, byte top);
    }
}
