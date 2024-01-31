using BookCatalogAPI.Core.Models.Records;
using BookCatalogAPI.Core.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogAPI.Core.Repositories
{
    public interface IBookCatalogRepository
    {
        Task<IEnumerable<BookRecord>> GetBookCatalogAsync(BookCatalogRequest request);
    }
}
