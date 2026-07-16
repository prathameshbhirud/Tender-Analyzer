using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TenderAnalyzer.Domain.Entities;

namespace TenderAnalyzer.Infrastructure.Persistence.Configurations;

public class TenderConfiguration: IEntityTypeConfiguration<Tender>
{
    public void Configure(EntityTypeBuilder<Tender> builder)
    {
        builder.ToTable("Tenders");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(x => x.FileName)
            .HasMaxLength(500);

        builder.Property(x => x.FilePath)
            .HasMaxLength(1000);

        builder.Property(x => x.Status)
            .IsRequired();
    }
}