using BookCatalogAPI.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogAPI.Core.Models.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime PublishDateUtc { get; set; }

        public Category Category { get; set; } = new();
    }
}
