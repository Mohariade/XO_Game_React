using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_And_Data_Layers.Models;
using System.Diagnostics.Contracts;
using Microsoft.Extensions.Options;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Business_And_Data_Layers.Data
{
    public class DataLayer : DbContext
    {

        public DataLayer() { }

        public DbSet<Game> Games { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=SQL5110.site4now.net;Initial Catalog=db_a9fbce_xogamedb;User Id=db_a9fbce_xogamedb_admin;Password=XOGameDB@123");

            base.OnConfiguring(optionsBuilder);
        }

    }
}
