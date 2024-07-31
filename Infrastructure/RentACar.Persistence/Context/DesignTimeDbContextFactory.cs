using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Persistence.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<RentACarPsqlDbContext>
    {
        public RentACarPsqlDbContext CreateDbContext(string[] args)
        {
            ConfigurationManager configurationManager = new ConfigurationManager();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/RentACar/Server"));
            configurationManager.AddJsonFile("appsettings.json");
            var builder = new DbContextOptionsBuilder<RentACarPsqlDbContext>();
            //var dbDataSource = new NpgsqlDataSourceBuilder(configurationManager.GetConnectionString("PostgreSql"));
            builder.UseSqlServer(configurationManager.GetConnectionString("Mssql"));
            return new RentACarPsqlDbContext(builder.Options);
        }
    }
}
