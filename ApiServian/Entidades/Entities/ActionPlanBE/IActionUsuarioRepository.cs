using ENTIDADES.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ENTIDADES.Entities.ActionPlanBE
{
   public interface IActionUsuarioRepository: IBaseRepository<Usuario>
    {

         IList<Usuario> GetAll();
    }
}
