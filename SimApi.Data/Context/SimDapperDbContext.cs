﻿using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimApi.Data.Context
{
    public class SimDapperDbContext
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;
        private readonly string databaseType;

        public SimDapperDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.databaseType = configuration.GetConnectionString("DbType");
            this.connectionString = GetConnection();
        }


        public string GetConnection()
        {
            switch (this.databaseType)
            {
                case "SQL":
                    return configuration.GetConnectionString("MsSqlConnection");
                case "PostgreSql":
                    return configuration.GetConnectionString("PostgreSqlConnection");
                default:
                    return configuration.GetConnectionString("DefaultConnection");
            }
        }

        public IDbConnection CreateConnection()
        {
            switch (this.databaseType)
            {
                case "SQL":
                    return new SqlConnection(connectionString);
                case "PostgreSql":
                    return new NpgsqlConnection(connectionString);
                default:
                    return new SqlConnection(connectionString);
            }
        }
    }
}
