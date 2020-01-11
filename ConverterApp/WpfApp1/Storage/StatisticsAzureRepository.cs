using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace WpfApp1
{
    internal class StatisticsAzureRepository : IStatisticsRepository
    {

        private CloudTable table;

        public StatisticsAzureRepository() {
            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(ConfigurationManager.AppSettings["StorageName"], ConfigurationManager.AppSettings["StorageKey"]), true);
            CloudTableClient client = storageAccount.CreateCloudTableClient();
            this.table = client.GetTableReference("StatisticsDawidJuszczak");
            this.table.CreateIfNotExists();
        }


        public void AddSingleStatistic(StatisticDTO item)
        {
            UsageStatiticsEntity statistic = new UsageStatiticsEntity(item);
            statistic.PartitionKey = string.Empty;
            statistic.RowKey = Guid.NewGuid().ToString();

            table.Execute(TableOperation.Insert(statistic));
        }

        public IEnumerable<StatisticDTO> GetAllStatistics()
        {
            TableQuery<UsageStatiticsEntity> statisticsQuery = new TableQuery<UsageStatiticsEntity>();
            return table.ExecuteQuery(statisticsQuery).Select(x => 
                new StatisticDTO() {
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