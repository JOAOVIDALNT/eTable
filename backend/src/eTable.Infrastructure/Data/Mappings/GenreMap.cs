using eTable.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eTable.Infrastructure.Data.Mappings
{
    public class GenreMap : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder
                .ToTable("Genres")
                .HasKey(x => x.Id);

            builder.Property(x => x.Description).HasMaxLength(30);
        }
    }
}
