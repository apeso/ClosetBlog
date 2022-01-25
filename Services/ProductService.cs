using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PMAprojekt.Models;
using PMAprojekt.Repositories;
namespace PMAprojekt.Services
{
    public class ProductService
    {
        private readonly ProductsRepository _productRepository;
        public ProductService(ProductsRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Models.Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public void Save(Product product)
        {
            _productRepository.Save(product);
        }
    }
}
