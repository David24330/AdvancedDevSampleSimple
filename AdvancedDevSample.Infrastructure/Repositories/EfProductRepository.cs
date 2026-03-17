using AdvancedDevSample.Domain.Entities;
using AdvancedDevSample.Domain.Interfaces.Products;
using AdvancedDevSample.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedDevSample.Infrastructure.Repositories
{
    public class EfProductRepository : IProductRepository
    {
        public Product? GetById(Guid id)
        { // accès base de données
            ProductEntity product = new() { Id = id, Price = 10, IsActive = true, Libelle = "" };
            var domainProduct = new Product(id: product.Id, prix: product.Price, isActive: product.IsActive, libelle: product.Libelle);

            return domainProduct;
        }
       
        public void Save(Product product)
        { // accès base de données
        }
    }
}
