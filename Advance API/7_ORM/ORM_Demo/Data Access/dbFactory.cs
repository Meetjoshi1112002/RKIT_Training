using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Demo.Data_Access
{
    public static class DBFactory
    {
        public static OrmLiteConnectionFactory GetConnection()
        {
            string urlToDB = "Server=localhost;database=orm_demo_mj;User=Admin;Password=gs@123";
            return new OrmLiteConnectionFactory(urlToDB, MySqlDialect.Provider);
        }
    }
}
