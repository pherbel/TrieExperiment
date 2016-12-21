using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trie.Abstractions;
using Trie.DataProvider.File;

namespace TrieTestConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ITrieFactory factory = new TrieFactory();
            using (ITrie trie = factory.LoadFromDataProvider(new FileDataSetProvider(new FileDataSetProviderSettings { FileName = "SampleDataSet.txt", Separator = ';' })).GetAwaiter().GetResult())
            {
                
            }
        }
    }
}
