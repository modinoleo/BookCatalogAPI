using BookCatalogAPI.Core.Repositories;
using BookCatalogAPI.Infrastructure.Repositories.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.Infrastructures.Repositories
{
    [TestClass]
    public class BookCatalogRepositoryTest : BaseRepositoryTests
    {
        [TestMethod]
        public async Task GetBookCatalogSearch_ShouldReturnAll()
        {
            var repo = new BookCatalogRepository(_dataContext);

            var request = new BookCatalogAPI.Core.Models.Request.BookCatalogRequest
            {
                PageSize = 10,
                PageNumber = 1
            };
            var result = await repo.GetBookCatalogAsync(request);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() > 0);
        }

    }
}
