using TenderAnalyzer.Application.Abstractions.Chunking;

namespace TenderAnalyzer.Infrastructure.Chunking;

public class FixedSizeTextChunker
    : ITextChunker
{
    private const int ChunkSize = 1000;

    public List<TextChunk> Chunk(int pageNumber, string content)
    {
        var result = new List<TextChunk>();

        for (var i = 0; i < content.Length; i += ChunkSize)
        {
            var length = Math.Min(ChunkSize, content.Length - i);

            result.Add(new TextChunk
            {
                PageNumber = pageNumber,
                Content = content.Substring(i, length)
            });
        }

        return result;
    }
}