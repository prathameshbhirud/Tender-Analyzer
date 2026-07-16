using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TenderAnalyzer.Domain.Entities;

namespace TenderAnalyzer.Infrastructure.Persistence.Configurations;

public class TenderSummaryConfiguration: IEntityTypeConfiguration<TenderSummary>
{
    public void Configure(EntityTypeBuilder<TenderSummary> builder)
    {
        builder.ToTable("TenderSummaries");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.SummaryJson).IsRequired();

        builder.Property(x => x.GeneratedAtUtc).IsRequired();

        builder.HasOne(x => x.Tender)
            .WithMany(x => x.Summaries)
            .HasForeignKey(x => x.TenderId);
    }
}