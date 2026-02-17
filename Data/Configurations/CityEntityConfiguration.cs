using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebTestMVC.Data.Configurations
{
    public class CityEntityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Name)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
