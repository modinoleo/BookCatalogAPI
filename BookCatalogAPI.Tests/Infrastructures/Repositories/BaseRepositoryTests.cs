using BookCatalogAPI.Core.Models.Configurations;
using BookCatalogAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogAPI.Tests.Infrastructures.Repositories
{
    public class BaseRepositoryTests
    {
        protected AppSettings _config;
        protected DataContext _dataContext;
        public BaseRepositoryTests()
        {
            _config = new AppSettings();
        }
        [TestInitialize]
        public void Setup()
        {
            var config = new AppSettings()
            {
                DBConnectionString = "Data Source=LAPTOP-Q4CNQBGI\\SQLEXPRESS; Initial Catalog=BookCatalog;Trusted_Connection=true;TrustServerCertificate=true;Connection Timeout=6000; Pooling=true;"
            };
            _config = config;

            var options = new DbContextOptionsBuilder<DataContext>()
               .UseSqlServer(_config.DBConnectionString)
               .Options;

            _dataContext = new DataContext(options);
        }
    }
}
