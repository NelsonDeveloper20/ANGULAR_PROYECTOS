using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreAngular.Models
{
    public class Producto
    {
        public Int32    IdProducto {get;set;}
        public String  Nombre {get;set;}
        public String Precio {get;set;}
        public String Imagen { get;set;}
        public String IdTipoProducto { get;set;}
        
    }
}
