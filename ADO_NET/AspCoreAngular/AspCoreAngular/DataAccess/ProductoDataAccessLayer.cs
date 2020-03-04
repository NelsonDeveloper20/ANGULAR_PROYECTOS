using AspCoreAngular.Interfaces;
using AspCoreAngular.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreAngular.DataAccess
{
    public class ProductoDataAccessLayer:IProducto
    {
        private string connectionString;
        public ProductoDataAccessLayer(IConfiguration configuration)
        {
            connectionString = configuration["ConnectionStrings:DefaultConnection"];
        }

        public IEnumerable<Producto> listarProducto()
        {
            try
            {
                List<Producto> lsProducto = new List<Producto>();

                using (SqlConnection cnm = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("ListarProducto",cnm);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cnm.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Producto prod = new Producto();
                        prod.IdProducto =Convert.ToInt32(rdr["idProducto"].ToString());
                        prod.Nombre = rdr["Nombre"].ToString();
                        prod.Precio = Convert.ToString(rdr["Precio"].ToString());
                        prod.Imagen = Convert.ToString(rdr["Imagen"].ToString());
                        prod.IdTipoProducto = Convert.ToString(rdr["TipoProducto"].ToString());                        
                        lsProducto.Add(prod);
                    }
                    cnm.Close();

                }
                return lsProducto;

            }catch(Exception e)
            {
                throw;
            }
        }
        public Producto ProductoXiD(Int32 id)
        {
            try
            {
                Producto prod = new Producto();
                using (SqlConnection cnm=new SqlConnection(connectionString))
                {

                    SqlCommand cmd = new SqlCommand("ProductoXid", cnm);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    cnm.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                       
                        prod.IdProducto = Convert.ToInt32(rdr["idProducto"].ToString());
                        prod.Nombre = rdr["Nombre"].ToString();
                        prod.Precio = Convert.ToString(rdr["Precio"].ToString());
                        prod.Imagen = Convert.ToString(rdr["Imagen"].ToString());
                        prod.IdTipoProducto = Convert.ToString(rdr["IdTipoProducto"].ToString());
                     }                  

                    cnm.Close();               
                
                }
                return prod;

            }
            catch
            {
                throw;
            }

        }
        public Int32 InsertarProducto(Producto prod)
        {
            try
            {

                using(SqlConnection cnm=new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("InsertarProducto",cnm);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombre", prod.Nombre);
                    cmd.Parameters.AddWithValue("@precio", prod.Precio);
                    cmd.Parameters.AddWithValue("@imagen", prod.Imagen);
                    cmd.Parameters.AddWithValue("@tipoproducto", prod.IdTipoProducto);
                    cnm.Open();
                    cmd.ExecuteNonQuery();
                    cnm.Close();
                }
                return 1;

            }catch(Exception e)
            {
                throw;
            }
        }
        public Int32 ModificarProducto(Producto prod)
        {
            try
            {

                using (SqlConnection cnm = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("ModificarProducto",cnm);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idproducto", prod.IdProducto);
                    cmd.Parameters.AddWithValue("@nombre", prod.Nombre);
                    cmd.Parameters.AddWithValue("@precio", prod.Precio);
                    cmd.Parameters.AddWithValue("@imagen", prod.Imagen);
                    cmd.Parameters.AddWithValue("@tipoproducto", prod.IdTipoProducto);
                    cnm.Open();
                    cmd.ExecuteNonQuery();
                    cnm.Close();
                }
                return 1;

            }
            catch (Exception e)
            {
                throw;
            }
        }
        public Int32 EliminarProducto(Int32 id)
        {
            try
            {
                using(SqlConnection cnm=new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("EliminarProducto",cnm);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProducto", id);
                    cnm.Open();
                    cmd.ExecuteNonQuery();
                    cnm.Close();
                }
                return 1;
                 
            }catch(Exception e)
            {
                throw;
            }
        }
        public IEnumerable<TipoProducto> ListarTipoProducto()
        {
            try
            {
                List<TipoProducto> lsTipoProducto = new List<TipoProducto>();
                using(SqlConnection cnm=new SqlConnection( connectionString))
                {
                    SqlCommand cmd = new SqlCommand("ListarTipoProducto",cnm);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cnm.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        TipoProducto tipoProd = new TipoProducto();
                        tipoProd.idProducto = Convert.ToInt32(rdr["idProducto"].ToString());
                        tipoProd.Descripcion = rdr["Descripcion"].ToString();

                        lsTipoProducto.Add(tipoProd);
                    }
                    return lsTipoProducto;
                }
                

            }catch(Exception ex)
            {
                throw;
            }
        }
        
    }
}
