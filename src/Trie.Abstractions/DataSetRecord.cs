using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Utf8;
using System.Threading.Tasks;

namespace Trie.Abstractions
{
    public struct DataSetRecord : IDataSetRecord
    {
        public DataSetRecord(Utf8String word, uint score)
        {
            Word = word;
            Score = score;
        }
        public uint Score { get; }

        public Utf8String Word { get; }
    }
}
