﻿
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Agridoce.Infra.Data.Configurations
{
    public static class ConnectionStringConfiguration
    {
        public static string ConnectionString() =>
             new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build().GetConnectionString("DefaultConnection");
    }
}
