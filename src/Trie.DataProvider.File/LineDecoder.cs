using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Linq;
using System.Threading.Tasks;
using Trie.Abstractions;

namespace Trie.DataProvider.File
{
    public class LineDecoder : IDataSetRecordDecoder
    {
        public bool TryDecode(ref ReadableBuffer input, out IDataSetRecord record)
        {
            ReadableBuffer slice;
            ReadCursor cursor;
            if (input.TrySliceTo((byte)'\r', (byte)'\n', out slice, out cursor))
            {
                record = new DataSetRecord(slice.GetUtf8String(), 1);
                input = input.Slice(cursor).Slice(1);
                return true;
            }

            record = null;
            return false;
        }
    }
}
