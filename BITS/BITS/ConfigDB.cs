﻿using System;

using Microsoft.Extensions.Configuration;

/*
 * dotnet tool install --global dotnet-ef
 * Use nuget package manager to install efcore, efcore.analyzers, design, tools and mysql.data.efcore
 * -- Install-Package Microsoft.EntityFrameworkCore.Tools could do from the console too
 * Get-Help about_EntityFrameworkCore from the console
 *        
 *      SScaffold-DbContext "server=127.0.0.1;uid=root;pwd=PASSWORD;database=bits" MySql.Data.EntityFrameworkCore -OutputDir Models -context BITSContext -project BITS -startupproject BITS -force
 */
namespace BITS
{
    public class ConfigDB
    {
        public static string GetMySqlConnectionString()
        {
            string folder = System.AppContext.BaseDirectory;
            var builder = new ConfigurationBuilder()
                    .SetBasePath(folder)
                    .AddJsonFile("mySqlSettings.json", optional: true, reloadOnChange: true);
           
            string connectionString = builder.Build().GetConnectionString("mySql");

            return connectionString;
        }
    }
}
