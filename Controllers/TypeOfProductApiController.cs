using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMAprojekt.Models;
using Newtonsoft.Json.Linq;
using PMAprojekt.DtoMappers;
using PMAprojekt.Services;


namespace PMAprojekt.Controllers
{
    [Route("api/typeofproduct")]
    [ApiController]
    public class TypeOfProductApiController : ControllerBase
    {
        private TypeOfProductService _typeofproductService;
        public TypeOfProductApiController(TypeOfProductService type)
        {
            _typeofproductService = type;
        }
        [HttpGet]
        public ActionResult<List<TypeOfProduct>> Get()
        {
            return _typeofproductService.GetAll().ToList();
        }
        [HttpPost("save")]
        public ActionResult Save([FromBody] JObject json)
        {
            var type = TypeOfProductDto.FromJson(json);
            _typeofproductService.Save(type);
            return Ok();
        }
    }
    
}
