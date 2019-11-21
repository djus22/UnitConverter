namespace WpfApp1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class UsageStatisticsModel : DbContext
    {
        public UsageStatisticsModel()
            : base("name=UsageStatisticsModel")
        {
        }

        public virtual DbSet<UsageStatistics> UsageStatistics { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsageStatistics>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<UsageStatistics>()
                .Property(e => e.BaseUnit)
                .IsUnicode(false);

            modelBuilder.Entity<UsageStatistics>()
                .Property(e => e.ConvertedUnit)
                .IsUnicode(false);
        }
    }
}
