namespace TenderAnalyzer.Application.Abstractions.Chunking;

public interface ITextChunker
{
    List<TextChunk> Chunk(int pageNumber, string content);
}