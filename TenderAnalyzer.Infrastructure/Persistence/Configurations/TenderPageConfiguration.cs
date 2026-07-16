using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TenderAnalyzer.Domain.Entities;

namespace TenderAnalyzer.Infrastructure.Persistence.Configurations;

public class TenderPageConfiguration: IEntityTypeConfiguration<TenderPage>
{
    public void Configure(EntityTypeBuilder<TenderPage> builder)
    {
        builder.ToTable("TenderPages");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.PageNumber).IsRequired();

        builder.Property(x => x.Content).IsRequired();

        builder.HasOne(x => x.Tender)
            .WithMany(x => x.Pages)
            .HasForeignKey(x => x.TenderId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}