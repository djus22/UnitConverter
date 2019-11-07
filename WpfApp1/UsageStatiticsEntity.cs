using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.ComponentModel.DataAnnotations;

namespace WpfApp1
{
    internal class UsageStatiticsEntity : TableEntity
    {
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



        public UsageStatiticsEntity() { }
        public UsageStatiticsEntity(StatisticDTO item)
        {
            this.IdUsageStatistics = item.IdUsageStatistics;
            this.Time = item.Time;
            this.Type = item.Type;
            this.BaseUnit = item.BaseUnit;
            this.BaseValue = item.BaseValue;
            this.ConvertedUnit = item.ConvertedUnit;
            this.ConvertedValue = item.ConvertedValue;
        }
    }
}