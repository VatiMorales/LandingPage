using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace VeterinariaVanesaMorales.Models
{
    public class MantenimientoContacto
    {
        private SqlConnection con;
        private void Conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["admin"].ToString();
            con = new SqlConnection(constr);
        }
        public int Alta(Contacto cont)//Inserta los elementos
        {
            Conectar();
            SqlCommand comando = new SqlCommand("insert into contacto(nombre,direccion,email,telefono,ciudad,mensaje)values(@nombre,@direccion,@email,@telefono,@ciudad,@mensaje)", con);

            //SqlDbType es para esepcificar que tipo de dato es en Sql Server.

           
            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters.Add("@direccion", SqlDbType.VarChar);
            comando.Parameters.Add("@email", SqlDbType.VarChar);
            comando.Parameters.Add("@telefono", SqlDbType.Int);
            comando.Parameters.Add("@ciudad", SqlDbType.VarChar);
            comando.Parameters.Add("@mensaje", SqlDbType.VarChar);


            //lee y modifica los datos.
            comando.Parameters["@nombre"].Value = cont.Nombre;
            comando.Parameters["@direccion"].Value = cont.Direccion;
            comando.Parameters["@email"].Value = cont.Email;
            comando.Parameters["@telefono"].Value = cont.Telefono;
            comando.Parameters["@ciudad"].Value = cont.Ciudad;
            comando.Parameters["@mensaje"].Value = cont.Mensaje;
            //se abre la cadena
            con.Open();
            int i = comando.ExecuteNonQuery();//devuelve el numero de filas afectadas.
            con.Close();
            return i;
        }
        public List<Contacto> RecuperarTodos()//nos trae los articulos que estan en la base de datos.
        {
            Conectar();//abre la conexion.
            List<Contacto> usuarios = new List<Contacto>();
            SqlCommand com = new SqlCommand("select id,nombre,direccion,email,telefono,ciudad,mensaje from contacto", con);

            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())//muestra los registros por linea, uno por uno.
            {
                Contacto cont = new Contacto
                {
                    Id = int.Parse(registros["id"].ToString()),
                    Nombre = registros["nombre"].ToString(),
                    Direccion = registros["direccion"].ToString(),
                    Email = registros["email"].ToString(),
                    Telefono = int.Parse(registros["telefono"].ToString()),
                    Ciudad = registros["ciudad"].ToString(),
                    Mensaje = registros["mensaje"].ToString()

                };
                usuarios.Add(cont);
            }
            con.Close();
            return usuarios;
        }
       
    }
}