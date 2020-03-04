using AspCoreAngular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreAngular.Interfaces
{
  public  interface IProducto
    {
        IEnumerable<Producto> listarProducto();
        Int32 InsertarProducto(Producto prod);
        Int32 ModificarProducto(Producto prod);
        Int32 EliminarProducto(Int32 id);
        IEnumerable<TipoProducto> ListarTipoProducto();
        Producto ProductoXiD(Int32 id);
    }
}
