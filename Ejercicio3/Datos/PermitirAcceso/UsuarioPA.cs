using Datos.AlmacenarEntidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.PermitirAcceso
{
    public class UsuarioPA
    {
        readonly string cadena = "Server=Localhost; port=3306; Database=ejercicio3; Uid=root; Pwd=123456;";

        MySqlConnection conn;
        MySqlCommand cmd;

        public Usuario Login(string Codigo, string Clave)
        {
            Usuario user = null;

            try
            {
                string sql = "SELECT * FROM usuarios WHERE Codigo=@Codigo AND Clave=@Clave;";
                conn = new MySqlConnection(cadena);
                conn.Open();
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Codigo", Codigo);
                cmd.Parameters.AddWithValue("@Clave", Clave);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    user = new Usuario();
                    user.Codigo = reader[0].ToString();
                    user.Nombre = reader[1].ToString();
                    user.Rol = reader[2].ToString();
                    user.Clave = reader[3].ToString();
                    user.EstaActivo = Convert.ToBoolean(reader[4]);
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception)
            {

            }
            return user;
        }

        public DataTable ListarUsuarios()
        {
            DataTable ListaUsuariosDT = new DataTable();

            try
            {
                string sql = "SELECT * FROM usuarios";
                conn = new MySqlConnection(cadena);
                conn.Open();
                cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                ListaUsuariosDT.Load(reader);
            }
            catch (Exception)
            {

            }
            return ListaUsuariosDT;
        }
    }
}
