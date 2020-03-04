using AspCoreAngular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreAngular.Interfaces
{
  public  interface IUsuario
    {
        IEnumerable<Usuario> ListarUsuario();
        Usuario ListarUsuarioXID(Int32 Id);
        IEnumerable<TipoUsuario> listarTipoUsuario();
        Int32 InsertarUsuario(Usuario user);
        Int32 ModificarUsuario(Usuario user);
        Int32 EliminarUsuario(Int32 id  );
    }
}
