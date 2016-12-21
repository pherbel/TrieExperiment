using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Utf8;
using System.Threading.Tasks;

namespace Trie.Abstractions
{
    public interface IDataSetRecord
    {

        Utf8String Word { get; }


        uint Score { get; }
    }
}
