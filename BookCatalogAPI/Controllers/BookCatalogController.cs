using BookCatalogAPI.Core.Models.DTOs;
using BookCatalogAPI.Core.Models.Request;
using BookCatalogAPI.Core.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalogAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookCatalogController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IBookCatalogService _service;

        public BookCatalogController(ILogger<WeatherForecastController> logger, IBookCatalogService service)
        {
            _logger = logger;
            _service = service;
        }
        [HttpPost(Name = "GetBookCatalog")]
        public async Task<IEnumerable<BookDTO>> GetBookCatalogAsync([FromBody] BookCatalogRequest request)
        {
            var result = await _service.GetBookCatalogAsync(request);
            return result;
        }
    }
}
