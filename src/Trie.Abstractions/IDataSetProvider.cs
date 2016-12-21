using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trie.Abstractions
{
    public interface IDataSetProvider
    {
        Task<List<IDataSetRecord>> Load();
    }
}
