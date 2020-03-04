using System;
using System.Collections.Generic;
using System.Text;
using ENTIDADES.Entities.ActionPlanBE;
namespace LOGNEGOCIO.Interfaces
{
 public   interface IUsuarioService
    {
        IList<Usuario> listarUarios();
    }
}
