using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PMAprojekt.Mappers;
using PMAprojekt.DbModels;

namespace PMAprojekt.Repositories
{
    public class TypeOfProductRepository
    {
        private readonly ClosetContext _dbContext;
        public TypeOfProductRepository(ClosetContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Models.TypeOfProduct> GetAll()
        {
            return _dbContext.TypeOfProduct.Select(
                x => TypeOfProductMappers.FromDatabase(x));
        }
        public void Save(Models.TypeOfProduct type)
        {
            var dbType = TypeOfProductMappers.ToDatabase(type); //podatak pogodan za bazu
            _dbContext.TypeOfProduct.Add(dbType);
            _dbContext.SaveChanges();
        }
    }
}
