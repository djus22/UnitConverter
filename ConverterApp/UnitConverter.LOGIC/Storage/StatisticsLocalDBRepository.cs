using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class StatisticsLocalDBRepository : IStatisticsRepository
    {
        public void AddSingleStatistic(StatisticDTO item)
        {
            using (UsageStatisticsModel db = new UsageStatisticsModel()) {
                db.UsageStatistics.Add(new UsageStatistics(item));
                db.SaveChanges();
            }
        }

        public IEnumerable<StatisticDTO> GetAllStatistics()
        {
            using (UsageStatisticsModel db = new UsageStatisticsModel()) {
                return db.UsageStatistics.Select(x => new StatisticDTO() {
                    IdUsageStatistics = x.IdUsageStatistics,
                    Time = x.Time,
                    Type = x.Type,
                    BaseUnit = x.BaseUnit,
                    BaseValue = x.BaseValue,
                    ConvertedUnit = x.ConvertedUnit,
                    ConvertedValue = x.ConvertedValue
                }).ToList();
            }
        }
    }
}
