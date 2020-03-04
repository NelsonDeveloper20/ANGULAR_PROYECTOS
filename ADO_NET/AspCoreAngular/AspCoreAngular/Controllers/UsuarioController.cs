using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspCoreAngular.Interfaces;
using AspCoreAngular.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspCoreAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuario objUsuario;
        public UsuarioController(IUsuario _usuario)
        {
            objUsuario = _usuario;
        }


        // GET: api/Usuario
        [HttpGet]
        [Route("Index")]
        public IEnumerable<Usuario> Get()
        {
            return objUsuario.ListarUsuario();
        }

        // GET: api/Usuario/5
        [HttpGet]
        [Route("Detalle/{id}")]
        public Usuario Get(int id)
        {
            return objUsuario.ListarUsuarioXID(id);
        }

        // POST: api/Usuario
        [HttpPost]
        [Route("Create")]
        public Int32 Post([FromBody] Usuario user)
        {
            return objUsuario.InsertarUsuario(user);
        }
        // PUT: api/Usuario/5
        [HttpPut]
        [Route("Edit")]
        public Int32 Put([FromBody] Usuario user)
        {
            return objUsuario.ModificarUsuario(user);
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        [Route("Delete/{id}")]
        public Int32 Delete(int id)
        {
          return  objUsuario.EliminarUsuario(id);
        }

        [HttpGet]
        [Route("listTipoUsuario")]
        public IEnumerable<TipoUsuario> detalle()
        {
            return objUsuario.listarTipoUsuario();
        }
    }
}
