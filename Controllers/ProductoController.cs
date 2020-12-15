using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WSProducto.Models;

namespace WSProducto.Controllers
{
    public class ProductoController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
           using(ProductosContext db=new ProductosContext())
            {
                var lst = db.Productos.ToList();
                return Ok(lst);
            }
           
        }
    }
}