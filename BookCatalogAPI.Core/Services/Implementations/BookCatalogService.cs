using AutoMapper;
using BookCatalogAPI.Core.Models.DTOs;
using BookCatalogAPI.Core.Models.Records;
using BookCatalogAPI.Core.Models.Request;
using BookCatalogAPI.Core.Repositories;
using BookCatalogAPI.Core.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogAPI.Core.Services.Implementations
{
    public class BookCatalogService : IBookCatalogService
    {
        private readonly IBookCatalogRepository _repository;
        private readonly IMapper _mapper;
        public BookCatalogService(IMapper mapper, IBookCatalogRepository repository)
        {
             _mapper = mapper;
            _repository = repository;
        }
        public async Task<List<BookDTO>> GetBookCatalogAsync(BookCatalogRequest request)
        {
            var bookCatalog = await _repository.GetBookCatalogAsync(request);
            var bookCatalogDTOList = _mapper.Map<List<BookRecord>,List<BookDTO>>(bookCatalog.ToList());
            return bookCatalogDTOList;
        }
    }
}
