using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebTestMVC.Data.Configurations
{
    public class StateEntityConfiguration : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.ToTable("State");

            builder.HasKey(s => s.Id);
            builder
                .Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(s => s.Code)
                .IsRequired()
                .HasMaxLength(2);
        }
    }
}
