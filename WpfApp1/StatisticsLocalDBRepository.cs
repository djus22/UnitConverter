using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class StatisticsLocalDBRepository : IStatisticsRepository
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
                return db.UsageStatistics.Select(x => new StatisticDTO(x)).ToList();
            }
        }
    }
}
