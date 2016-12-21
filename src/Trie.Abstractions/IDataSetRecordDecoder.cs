using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Linq;
using System.Threading.Tasks;

namespace Trie.Abstractions
{
    public interface IDataSetRecordDecoder
    {
        bool TryDecode(ref ReadableBuffer input, out IDataSetRecord record);
    }
}
