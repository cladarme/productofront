using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WSProducto.Models;
using WSProducto.Models.Response;
using WSProducto.Models.Request;
namespace WSProducto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
       
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();
            oRespuesta.Exito = 0;
            try
            {            
            using(ProductosContext db=new ProductosContext())
            {
                var lst = db.Productos.ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = lst;
               
            }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);

        }

        [HttpPost]
        public IActionResult Add(ClienteRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
           
            try
            {
                using (ProductosContext db = new ProductosContext())
                {
                    Producto oProducto = new Producto();
                                        
                    oProducto.Nombre = oModel.Nombre;
                    oProducto.PrecioUnitario = oModel.precioUnitario;
                    oProducto.Costo = oModel.costo;

                    db.Productos.Add(oProducto);
                   
                    db.SaveChanges();
                    oRespuesta.Exito = 1;

                }

             

            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }


        [HttpPut]
        public IActionResult Edit(ClienteRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                using (ProductosContext db = new ProductosContext())
                {
                    
                    Producto oProducto = db.Productos.Find(oModel.Id);
                    oProducto.Nombre = oModel.Nombre;
                    oProducto.PrecioUnitario = oModel.precioUnitario;
                    oProducto.Costo = oModel.costo;
                    db.Entry(oProducto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.Productos.Add(oProducto);

                    db.SaveChanges();
                    oRespuesta.Exito = 1;

                }
                               
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                using (ProductosContext db = new ProductosContext())
                {

                    Producto oProducto = db.Productos.Find(id);
                    db.Remove(oProducto);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;

                }

            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }
    }
}