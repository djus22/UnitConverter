using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WpfApp1;

namespace CurrencyPlugin
{
    public class CurrencyUnits : UnitsContainer
    {
        private List<Unit> _units;

        public override string Name => "Waluta";

        public CurrencyUnits() {
            _units = new List<Unit> {
                new Unit(this.Name, "PL", x => x, x => x),
                new Unit(this.Name, "EUR", x => x * getRate("EUR"), x => x / getRate("EUR"))
            };
        }

        public override List<Unit> _unitList => _units;

        private double getRate(string currency)
        {
            string url = @"http://api.nbp.pl/api/exchangerates/tables/A/today/?format=json";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                TableObject[] tables = JsonConvert.DeserializeObject<TableObject[]>(json);

                if (tables.Length > 0)
                {
                    RateObject rate = tables[0].Rates.Where(r => r.Code == currency).FirstOrDefault();

                    if (rate != null)
                    {
                        string rate_str = rate.Mid.Replace('.', ',');
                        return double.Parse(rate_str);
                    }
                }
            }

            return 0;
        }

        public class TableObject
        {
            public string Table { get; set; }
            public DateTime? EffectiveDate { get; set; }
            public RateObject[] Rates { get; set; }
        }

        public class RateObject
        {
            public string Currency { get; set; }
            public string Code { get; set; }
            public string Mid { get; set; }
        }
    }
}
