using eTable.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eTable.Infrastructure.Data.Mappings
{
    public class AuthorMap : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder
                .ToTable("Authors")
                .HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(50);
        }
    }
}
