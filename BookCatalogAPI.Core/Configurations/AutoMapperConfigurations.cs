using AutoMapper;
using BookCatalogAPI.Core.Models.DTOs;
using BookCatalogAPI.Core.Models.Records;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogAPI.Core.Configurations
{
    public static class AutoMapperConfigurations
    {
        public static void ConfigurationAutoMapper(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton(CreateMapper());
        }
        public static IMapper CreateMapper()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BookRecord, BookDTO>();
            });
            return configuration.CreateMapper();
        }
    }
}
