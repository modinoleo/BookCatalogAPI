using BookCatalogAPI.Core.Models.Records;
using BookCatalogAPI.Core.Models.Request;
using BookCatalogAPI.Core.Repositories;
using BookCatalogAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogAPI.Infrastructure.Repositories.Implementations
{
    public class BookCatalogRepository : IBookCatalogRepository
    {
        private readonly DataContext _context;
        public BookCatalogRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<BookRecord>> GetBookCatalogAsync(BookCatalogRequest request)
        {
            try
            {
                var query = _context.Books
                                .AsQueryable();

                // Apply filters based on the request
                if (!string.IsNullOrEmpty(request.Title))
                {
                    query = query.Where(b => b.Title.Contains(request.Title, StringComparison.OrdinalIgnoreCase));
                }

                if (request.CategoryId > 0)
                {
                    query = query.Where(b => b.CategoryId == request.CategoryId);
                }
                if (request.PublishDateTo != null && request.PublishDateTo.HasValue)
                {
                    query = query.Where(b => b.PublishDateUtc <= request.PublishDateTo.Value);
                }
                if (request.PublishDateFrom != null && request.PublishDateFrom.HasValue)
                {
                    query = query.Where(b => b.PublishDateUtc >= request.PublishDateFrom.Value);
                }
                if (request.PageSize > 0)
                {
                    query = query.Skip((request.PageNumber - 1) * request.PageSize)
                                 .Take(request.PageSize);
                }
                var result = await query
                     .Select(b => new BookRecord
                     {
                         Id = b.Id,
                         Title = b.Title,
                         Description = b.Description,
                         Category = b.Category,
                     })
                     .ToListAsync();

                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
    }
}
