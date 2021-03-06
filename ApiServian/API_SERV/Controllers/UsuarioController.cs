﻿using ENTIDADES.Entities.ActionPlanBE;
using LOGNEGOCIO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_SERV.Controllers
{
    public class UsuarioController : ApiController
    {
        IUsuarioService _UsuarioService;
        public UsuarioController(IUsuarioService usuarioservice)
        {
            _UsuarioService = usuarioservice;
        }
        // GET: api/Usuario
        public IEnumerable<Usuario> Get()
        {
            return _UsuarioService.listarUarios();
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
