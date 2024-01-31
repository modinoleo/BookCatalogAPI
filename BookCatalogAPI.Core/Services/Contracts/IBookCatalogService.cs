using BookCatalogAPI.Core.Models.DTOs;
using BookCatalogAPI.Core.Models.Records;
using BookCatalogAPI.Core.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogAPI.Core.Services.Contracts
{
    public interface IBookCatalogService
    {
        Task<List<BookDTO>> GetBookCatalogAsync(BookCatalogRequest request);
    }
}
