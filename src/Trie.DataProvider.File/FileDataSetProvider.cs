using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trie.Abstractions;

namespace Trie.DataProvider.File
{
    public class FileDataSetProvider:IDataSetProvider
    {

        private readonly FileDataSetProviderSettings _settings;
        public FileDataSetProvider(FileDataSetProviderSettings settings)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            if (string.IsNullOrEmpty(settings.FileName))
                throw new ArgumentNullException(nameof(settings.FileName));

            _settings = settings;
        }

        public ValueTask<List<IDataSetNode>> Load()
        {
            throw new NotImplementedException();
        }
    }
}
