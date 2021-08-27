using Domain.Voyages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Repositories.Mappings
{
    public class VoyageMappings : IEntityTypeConfiguration<Voyage>
    {
        public void Configure(EntityTypeBuilder<Voyage> builder)
        {
            builder.HasKey(v => v.Number);

            builder.Property(v => v.State);

            builder.OwnsOne(v => v.BerthPlan, bp =>
            {
                bp.Property(b => b.FromDate);
                bp.Property(b => b.ToDate);

                bp.Property(b => b.FromMeter);
                bp.Property(b => b.FromDate);
            });
        }
    }
}
