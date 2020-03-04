using System;
using System.Collections.Generic;
using System.Text;
using LOGNEGOCIO.Interfaces;
using ENTIDADES.Entities.ActionPlanBE;
namespace LOGNEGOCIO.Services
{
  public  class UsuarioService : IUsuarioService
    {
        private readonly IActionUsuarioRepository _usuarioRepository;
        public UsuarioService(IActionUsuarioRepository liniaRepository)
        {
            _usuarioRepository = liniaRepository;
        }

        public IList<Usuario> listarUarios()
        {
            try
            {
                return _usuarioRepository.GetAll();
            }
            catch
            {
                throw;
            }
        }
    }
}
