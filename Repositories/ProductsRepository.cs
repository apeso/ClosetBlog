using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PMAprojekt.Mappers;
using PMAprojekt.DbModels;
using Microsoft.EntityFrameworkCore;

namespace PMAprojekt.Repositories
{
    public class ProductsRepository
    {
        private readonly ClosetContext _dbContext;
        public ProductsRepository(ClosetContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Models.Product> GetAll()
        {
            return _dbContext.Product
                .Include(z=>z.IdTypeOfProduct)
                .Select(
                x => ProductsMappers.FromDatabase(x)
                );
        }
        public void Save(Models.Product product)
        {
            var dbProduct = ProductsMappers.ToDatabase(product); //podatak pogodan za bazu
            _dbContext.Product.Add(dbProduct);
            _dbContext.SaveChanges();
        }
    }
}
