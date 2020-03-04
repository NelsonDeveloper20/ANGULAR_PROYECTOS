using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreAngular.Models
{
    public class Usuario
    {
        public Int32   idUsuario {get ;set ;}
        public String  Nombre {get ;set ;}
        public String Apellido { get ;set ;}
        public String Email { get ;set ;}
        public String Clave { get ;set ;}
        public String Imagen { get ;set ;}
        public String idTipoUsuario { get ;set ;}
    }
}
