using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LOGNEGOCIO.Interfaces;
using ENTIDADES.Entities.ActionPlanBE;
namespace ApiServian.Controllers
{
    [Route("api/[controller]")]
   
    public class UsuarioController : ApiController
    {
        IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService ProcesoService)
        {
            _usuarioService = ProcesoService;
        }
        // GET: api/Usuario
        [HttpGet]
        [Route("Index")]
        public IList<Usuario> listar()
        {
            return _usuarioService.listarUarios();
        }
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Usuario/5
        public string Get(int id)
        {
            return "value";
        }
        // POST: api/Usuario
        public void Post([FromBody]string value)
        {
        }
        // PUT: api/Usuario/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Usuario/5
        public void Delete(int id)
        {
        }
    }
}
