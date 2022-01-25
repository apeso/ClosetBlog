using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PMAprojekt.Models;
using PMAprojekt.Repositories;
namespace PMAprojekt.Services
{
    public class TypeOfProductService
    {
        private readonly TypeOfProductRepository _topRepository;
        public TypeOfProductService(TypeOfProductRepository topRepository)
        {
            _topRepository = topRepository;
        }

        public IEnumerable<Models.TypeOfProduct> GetAll()
        {
            return _topRepository.GetAll();
        }

        public void Save(TypeOfProduct top)
        {
            _topRepository.Save(top);
        }
    }
}
