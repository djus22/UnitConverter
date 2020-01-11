using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public interface IStatisticsRepository
    {
        void AddSingleStatistic(StatisticDTO item);
        IEnumerable<StatisticDTO> GetAllStatistics();

    }
}
