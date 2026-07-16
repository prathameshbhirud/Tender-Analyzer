using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TenderAnalyzer.Domain.Entities;

namespace TenderAnalyzer.Infrastructure.Persistence.Configurations;

public class TenderChunkConfiguration: IEntityTypeConfiguration<TenderChunk>
{
    public void Configure(EntityTypeBuilder<TenderChunk> builder)
    {
        builder.ToTable("TenderChunks");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.PageNumber).IsRequired();

        builder.Property(x => x.ChunkText).IsRequired();

        builder.Property(x => x.ChunkIndex).IsRequired();

        builder.Property(x => x.CreatedAtUtc).IsRequired();

        builder.HasOne(x => x.Tender)
            .WithMany(x => x.Chunks)
            .HasForeignKey(x => x.TenderId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}