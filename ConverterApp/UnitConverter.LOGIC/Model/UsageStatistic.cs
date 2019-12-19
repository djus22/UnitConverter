namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UsageStatistics
    {
        [Key]
        public int IdUsageStatistics { get; set; }

        public DateTime? Time { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        [StringLength(50)]
        public string BaseUnit { get; set; }

        public double? BaseValue { get; set; }

        [StringLength(50)]
        public string ConvertedUnit { get; set; }

        public double? ConvertedValue { get; set; }


        public UsageStatistics(StatisticDTO item)
        {
            this.IdUsageStatistics = item.IdUsageStatistics;
            this.Time = item.Time;
            this.Type = item.Type;
            this.BaseUnit = item.BaseUnit;
            this.BaseValue = item.BaseValue;
            this.ConvertedUnit = item.ConvertedUnit;
            this.ConvertedValue = item.ConvertedValue;
        }

        public UsageStatistics()
        {
        }
    }
}
