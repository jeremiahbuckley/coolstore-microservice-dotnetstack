using System;
using System.Collections.Generic;

using CatalogService.Models;

namespace CatalogService {
    public interface ICatalogSvc {
        IList<Product> GetProducts();

        void Add(Product product);

        void AddAll(IList<Product> products);
    }
}