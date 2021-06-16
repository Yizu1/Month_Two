using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL_Common
{
    public static class ConfigurationManager
    {
        public readonly static IConfiguration configuration;

        static ConfigurationManager()
        {
            configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", true).Build();
        }


        public static string conn
        {
            get { return configuration.GetConnectionString("MySqlConnection"); }
        }
    }
}
