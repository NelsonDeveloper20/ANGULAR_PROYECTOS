using ENTIDADES.Entities.ActionPlanBE;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace ACDATOS.Repositories
{
  public  class ActionUsuarioRepository : IActionUsuarioRepository
    {
        public int Delete(int id, string modifiedBy, DateTime modifiedDate)
        {
            throw new NotImplementedException();
        }
        public IList<Usuario> GetAll()
        {
            var database = DatabaseFactory.CreateDatabase();

            IList<Usuario> lsUsuario = new List<Usuario>();
            try
            {
                using (var cmd = database.GetStoredProcCommand("ListarUsuario"))
                {
                    using (var reader = database.ExecuteReader(cmd))
                    {

                        while (reader.Read())
                        {
                            Usuario user = new Usuario();
                            user.idUsuario = Convert.ToInt32(reader["idUsuario"].ToString());
                            user.Nombre = reader["Nombre"].ToString();
                            user.Apellido = reader["Apellido"].ToString();
                            user.Email = reader["Email"].ToString();
                            user.Imagen = reader["Imagen"].ToString();
                            user.idTipoUsuario = reader["TipoUsuario"].ToString();
                            lsUsuario.Add(user);
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
            return lsUsuario;

        }

        public Usuario GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Usuario data)
        {
            throw new NotImplementedException();
        }

        public int Update(Usuario data)
        {
            throw new NotImplementedException();
        }
    }
}
