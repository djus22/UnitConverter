using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace WpfApp1
{
    public class ContainersApi
    {
        public List<UnitsContainer> GetContainers()
        {
            string url = @"http://localhost:56663/api/containers/";

            using (WebClient client = new WebClient())
            {
                byte[] jsonData = client.DownloadData(url);
                string json = Encoding.UTF8.GetString(jsonData);

                UnitsContainer[] containers = JsonConvert.DeserializeObject<UnitsContainer[]>(json);

                return new List<UnitsContainer>(containers);

            }
        }

        public static double Convert(string baseType, string convertedType, string baseVal,
            string containerType)
        {
            string url = @"http://localhost:56663/api/containers/convert?";

            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString.Add("baseType", baseType);
            queryString.Add("convertedType", convertedType);
            queryString.Add("baseVal", baseVal);
            queryString.Add("containerType", containerType);

            using (WebClient client = new WebClient())
            {
                string urlWithParameters = url + queryString.ToString();

                string valueString = client.DownloadString(urlWithParameters);

                return double.Parse(valueString);
            }
        }


        public class UnitsContainer
        {
            public string Name { get; set; }
            public List<Unit> _unitList { get; set; }

            internal bool Convert(string baseType, double baseVal, string convertedType, out double score)
            {
                string baseValue = baseVal.ToString();
                score = ContainersApi.Convert(baseType, convertedType, baseValue, Name);
                return true;
            }
        }

        public class Unit
        {
            public string type { get; set; }
            public string name { get; set; }
            public Func<double, double> toBase { get; set; }
            public Func<double, double> fromBase { get; set; }
        }
    }
}
