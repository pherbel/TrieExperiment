using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Linq;
using System.Threading.Tasks;
using Trie.Abstractions;
using System.IO.Pipelines.File;
using System.IO.Pipelines.Text.Primitives;
using System.IO;

namespace Trie.DataProvider.File
{
    public class FileDataSetProvider : IDataSetProvider
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


        public async Task<List<IDataSetRecord>> Load()
        {
            var result = new List<IDataSetRecord>();
            using (var pipelineFactory = new PipelineFactory())
            {
                var decoder = new LineDecoder();
                IPipelineReader pipelineReader = pipelineFactory.ReadFile(_settings.FileName);
                try
                {
                    while (true)
                    {
                        var readResult = await pipelineReader.ReadAsync();
                        var input = readResult.Buffer;

                        if (input.IsEmpty)
                        {
                            break;
                        }
                        try
                        {
                            IDataSetRecord record;
                            while (decoder.TryDecode(ref input, out record))
                            {
                                result.Add(record);
                            }


                        }
                        finally
                        {
                            pipelineReader.Advance(input.End);
                        }

                    }
                }
                finally
                {
                    pipelineReader.Complete();
                }
            }
            return result;
        }



    }
}
