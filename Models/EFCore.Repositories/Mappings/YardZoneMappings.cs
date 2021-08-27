using Domain.YardZones;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Repositories.Mappings
{
    public class YardZoneMappings : IEntityTypeConfiguration<YardZone>
    {
        public void Configure(EntityTypeBuilder<YardZone> builder)
        {
            builder.HasKey(y => y.Number);

            builder.OwnsMany(y => y.Berths, br =>
            {
                br.Property(b => b.FromMeter);
                br.Property(b => b.ToMeter);
                br.Property(b => b.Name);
            });

            builder.OwnsOne(y => y.BerthPlanSheet, bps =>
            {
                bps.OwnsMany(b => b.Points, brp =>
                {
                    brp.HasKey(p => new { p.Date, p.ZoneMeter });

                    brp.Property(p => p.VoyageNumber);
                });

                builder.OwnsOne(y => y.ZoneDistance, zd =>
                {
                    zd.OwnsMany(b => b.DistancePoints, db =>
                    {
                        db.HasKey(p => p.MeterNumber);

                        db.Property(p => p.BerthName);
                    });
                });
            });
        }
    }
}
