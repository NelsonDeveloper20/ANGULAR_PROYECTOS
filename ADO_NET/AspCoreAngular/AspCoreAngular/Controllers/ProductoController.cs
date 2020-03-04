using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspCoreAngular.DataAccess;
using AspCoreAngular.Interfaces;
using AspCoreAngular.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspCoreAngular.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProducto objProducto;

        public ProductoController(IProducto _objProducto)
        {
            objProducto = _objProducto;
        }
        // GET: api/Producto
     
        [HttpGet]
        [Route("index")]
        public IEnumerable<Producto> Get()
        {
            return objProducto.listarProducto();
        }

        // GET: api/Producto/5
        [HttpGet]
        [Route("Details/{id}")]
        public Producto Details(int id)
        {
            return objProducto.ProductoXiD(id);
        }

        // POST: api/Producto 
        [HttpPost]
        [Route("Create")] 
        public Int32 Create([FromBody] Producto prod)
        {
            return objProducto.InsertarProducto(prod);

        }

        // PUT: api/Producto/5 
        [HttpPut]
        [Route("Edit")] 
        public Int32 Edit([FromBody] Producto prod)
        {
            return objProducto.ModificarProducto(prod);

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        [Route("Delete/{id}")]
        public Int32 Delete(Int32 id)
        {
            return objProducto.EliminarProducto(id);

        }

        [HttpGet]
        [Route("listarTipoProducto")]
        public IEnumerable<TipoProducto> TipoProductos(){
            return objProducto.ListarTipoProducto();

        }
    }
}
