using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayerUWP
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceData" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceData.svc or ServiceData.svc.cs at the Solution Explorer and start debugging.
    public class ServiceData : IServiceData
    {
        public async Task<List<SomeData>> GetData_Async()
        {
            return await Task.Factory.StartNew(() => GetData());
        }

        public List<SomeData> GetData()
        {
            mysqlazuredatabaseEntities DataBaseSQLAzure = new mysqlazuredatabaseEntities();
            return DataBaseSQLAzure.SomeDatas.ToList();
        }
        
        public async Task<bool> AddData_Async(string Name, string Mail, int Age)
        {
            return await Task.Factory.StartNew(() => AddData(Name, Mail, Age));
        }

        public bool AddData(string Name, string Mail, int Age)
        {
            mysqlazuredatabaseEntities DataBaseSQLAzure = new mysqlazuredatabaseEntities();

            SomeData NewData = new SomeData()
            {
                 Age = Age,
                  Mail = Mail,
                   Name = Name,
            };

            DataBaseSQLAzure.SomeDatas.Add(NewData);
            DataBaseSQLAzure.SaveChanges();

            return true;
        }
    }
}
