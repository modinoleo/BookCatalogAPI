using BookCatalogAPI.Core.Repositories;
using BookCatalogAPI.Infrastructure.Repositories.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogAPI.Tests.Infrastructures.Repositories
{
    [TestClass]
    public class BookCatalogRepositoryTest : BaseRepositoryTests
    {
        [TestMethod]
        public async Task GetBookCatalogSearch_ShouldReturnAll()
        {
            var repo = new BookCatalogRepository(_dataContext);

            var request = new Core.Models.Request.BookCatalogRequest
            {
                CategoryId = 1,
            };
            var result = repo.GetBookCatalogAsync(request);

            Assert.IsNotNull(result);
        }

    }
}
