using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace PMAprojekt.Controllers
{
    public class TypeOfProductController : Controller
    {
        [Authorize(Roles = "Admin")]
        public IActionResult TypeOfProduct()
        {
            return View();
        }
        
    }
}
