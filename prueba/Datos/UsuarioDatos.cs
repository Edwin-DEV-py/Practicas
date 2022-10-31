using prueba.Models;
using System.Data.SqlClient;
using System.Data;

namespace prueba.Datos
{
    public class UsuarioDatos
    {
        public List<Usuario> Listar()
        {
            var Lista = new List<Usuario>();
            var cn = new Conexion();

            using(var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("lista", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using(var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Lista.Add(new Usuario()
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            Nombre = dr["Nombre"].ToString(),
                            Apellido = dr["Apellido"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Correo = dr["Correo"].ToString()
                        });
                    }
                }
            }

            return Lista;
        }

        public Usuario Obtener(int Id)
        {

            var usuario = new Usuario();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("Obtener", conexion);
                cmd.Parameters.AddWithValue("Id", Id);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        usuario.Id = Convert.ToInt32(dr["IdContacto"]);
                        usuario.Nombre = dr["Nombre"].ToString();
                        usuario.Apellido = dr["Apellido"].ToString();
                        usuario.Telefono = dr["Telefono"].ToString();
                        usuario.Correo = dr["Correo"].ToString();
                    }
                }
            }

            return usuario;
        }

        public bool Guardar(Usuario usuario)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("Guardar", conexion);
                    cmd.Parameters.AddWithValue("Nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", usuario.Apellido);
                    cmd.Parameters.AddWithValue("Telefono", usuario.Telefono);
                    cmd.Parameters.AddWithValue("Correo", usuario.Correo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;


            }
            catch (Exception e)
            {

                string error = e.Message;
                rpta = false;
            }



            return rpta;
        }
    }
}
