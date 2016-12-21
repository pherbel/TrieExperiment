using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Linq;
using System.Text.Utf8;
using System.Threading.Tasks;

namespace Trie.DataProvider.File
{
    public static class ReadableBufferExtensions
    {
        /// <summary>
        /// Decodes the utf8 encoded bytes in the <see cref="ReadableBuffer"/> into a <see cref="Utf8String"/>
        /// </summary>
        /// <param name="buffer">The buffer to decode</param>
        public static unsafe Utf8String GetUtf8String(this ReadableBuffer buffer)
        {
            if (buffer.IsEmpty)
            {
                return Utf8String.Empty;
            }

            ReadOnlySpan<byte> textSpan;

            if (buffer.IsSingleSpan)
            {
                textSpan = buffer.First.Span;
            }
            else if (buffer.Length < 128) // REVIEW: What's a good number
            {
                var data = stackalloc byte[128];
                var destination = new Span<byte>(data, 128);

                buffer.CopyTo(destination);

                textSpan = destination.Slice(0, buffer.Length);
            }
            else
            {
                // Heap allocated copy to parse into array (should be rare)
                textSpan = new ReadOnlySpan<byte>(buffer.ToArray());
            }

            return new Utf8String(textSpan);
        }
    }
}
