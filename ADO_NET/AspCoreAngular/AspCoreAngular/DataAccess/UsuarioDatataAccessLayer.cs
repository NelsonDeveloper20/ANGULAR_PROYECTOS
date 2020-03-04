using AspCoreAngular.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using AspCoreAngular.Interfaces;

namespace AspCoreAngular.DataAccess
{
    public class UsuarioDatataAccessLayer: IUsuario
    {
        private String CN;

        public UsuarioDatataAccessLayer(IConfiguration configuration)
        {
            CN = configuration["ConnectionStrings:DefaultConnection"];
        }

        public IEnumerable<Usuario> ListarUsuario()
        {
            List<Usuario> lsUsuario = new List<Usuario>();
            try
            {
                using (SqlConnection cnm = new SqlConnection(CN))
                {
                    SqlCommand cmd = new SqlCommand("ListarUsuario", cnm);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cnm.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Usuario user = new Usuario();
                        user.idUsuario = Convert.ToInt32(rdr["idUsuario"].ToString());
                        user.Nombre = rdr["Nombre"].ToString();
                        user.Apellido = rdr["Apellido"].ToString();
                        user.Email = rdr["Email"].ToString();
                        user.Imagen = rdr["Imagen"].ToString();
                        user.idTipoUsuario = rdr["TipoUsuario"].ToString();
                        lsUsuario.Add(user);
                    }
                    return lsUsuario;

                }
            }
            catch
            {
                throw;
            }
        }
        public Usuario ListarUsuarioXID(Int32  Id)
        {
            Usuario user = new Usuario();
            try
            {
                using(SqlConnection cnm=new SqlConnection(CN))
                {
                    SqlCommand cmd = new SqlCommand("ListarUsuarioXId", cnm);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", Id);
                    cnm.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    { 
                        user.Nombre = rdr["Nombre"].ToString();
                        user.Apellido = rdr["Apellido"].ToString();
                        user.Email = rdr["Email"].ToString();
                        user.Imagen = rdr["Imagen"].ToString();
                        user.idTipoUsuario = rdr["idTipoUsuario"].ToString();
                    }
                    
                }
                return user;
            }
            catch
            {
                throw;
            }
        }
        public IEnumerable<TipoUsuario> listarTipoUsuario()
        {
            List<TipoUsuario> lsTipoUsuario = new List<TipoUsuario>();
            try
            {
                using(SqlConnection cnm=new SqlConnection(CN))
                {
                    SqlCommand cmd = new SqlCommand("ListarTipoUsuario", cnm);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cnm.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        TipoUsuario tipo = new TipoUsuario();
                        tipo.idTipoUsuario = Convert.ToInt32(rdr["idTipoUsuario"].ToString());
                        tipo.Descripcion = rdr["Descripcion"].ToString();
                        lsTipoUsuario.Add(tipo);
                    }

                }
                return lsTipoUsuario;

            }
            catch
            {
                throw;
            }
        }
        public Int32 InsertarUsuario(Usuario user)
        {
            try
            {
                using(SqlConnection cnm=new SqlConnection(CN))
                {
                    SqlCommand cmd = new SqlCommand("InsertarUsuario", cnm);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombre", user.Nombre);
                    cmd.Parameters.AddWithValue("@apellido", user.Apellido);
                    cmd.Parameters.AddWithValue("@email", user.Email);
                    cmd.Parameters.AddWithValue("@clave", user.Clave);
                    cmd.Parameters.AddWithValue("@imagen", user.Imagen);
                    cmd.Parameters.AddWithValue("@idtipousuario", user.idTipoUsuario);
                    cnm.Open();
                    cmd.ExecuteScalar();

                }
                return 1;
            }
            catch
            {
                throw;
            }
        }
        public Int32 ModificarUsuario(Usuario user)
        {
            try
            {
                using (SqlConnection cnm = new SqlConnection(CN))
                {
                    SqlCommand cmd = new SqlCommand("ModificarUsuario", cnm);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdUsuario", user.idUsuario);
                    cmd.Parameters.AddWithValue("@nombre", user.Nombre);
                    cmd.Parameters.AddWithValue("@apellido", user.Apellido);
                    cmd.Parameters.AddWithValue("@email", user.Email);
                    cmd.Parameters.AddWithValue("@clave", user.Clave);
                    cmd.Parameters.AddWithValue("@imagen", user.Imagen);
                    cmd.Parameters.AddWithValue("@idtipousuario", user.idTipoUsuario);
                    cnm.Open();
                    cmd.ExecuteScalar();

                }
                return 1;
            }
            catch
            {
                throw;
            }
        }
        public Int32 EliminarUsuario(Int32 id)
        {
            try
            {
                using (SqlConnection cnm = new SqlConnection(CN))
                {
                    SqlCommand cmd = new SqlCommand("EliminarUsuario", cnm);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idUsuario",id); 
                    cnm.Open();
                    cmd.ExecuteScalar();

                }
                return 1;
            }
            catch
            {
                throw;
            }
        }
    }
}
