using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Where_Did_I_Leave_It.Domain.Entities;
using Where_Did_I_Leave_It.Domain.Enum;

namespace Where_Did_I_Leave_It.Infrastrcuture.EF.Config
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>, IEntityTypeConfiguration<ItemHistory>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(i => i.Name).IsRequired().HasMaxLength(50);
            builder.Property(i => i.Note).IsRequired(false).HasMaxLength(1000);
            builder.Property(i => i.Location).IsRequired().HasMaxLength(100);

            builder.HasMany(i => i.History)
                .WithOne(i => i.Item)
                .HasForeignKey(ih => ih.ItemId);

            builder.ToTable("Items");
        }

        public void Configure(EntityTypeBuilder<ItemHistory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(i => i.Name).IsRequired().HasMaxLength(50);
            builder.Property(i => i.Note).IsRequired(false).HasMaxLength(1000);
            builder.Property(i => i.Location).IsRequired().HasMaxLength(100);

            var changeTypeValueConvertor = new ValueConverter<ChangeType, string>(
                c => c.ToString(), 
                v => (ChangeType)Enum.Parse(typeof(ChangeType), v));

            builder.Property(p => p.ChangeType).HasConversion(changeTypeValueConvertor);

            builder.ToTable("ItemHistories");

        }
    }
}
