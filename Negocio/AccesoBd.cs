using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    internal class AccesoBd
    {

        //defino pero no instancio los objs de conexion 
        private SqlConnection _Conexion;
        private SqlCommand _Comando;
        private SqlDataReader _Lector;

        //propiedad para leer el lector!
        public SqlDataReader Lector
        {
            get { return _Lector; }
        }

        public AccesoBd()
        {
            //usamos el . o localhost para que acceda directamente, independientemente quien use
            // ojo si usamos sqlexpress01 o + , por si tenemos varias instancias corriendo


            // ahora si instancio los objs aca. para que se creen al crear un obj de esta clase
            _Conexion = new SqlConnection(@"server =.\SQLEXPRESS;database=CATALOGO_P3_DB ; integrated security = true"); // si fuera otra autenticacion que no la de microsoft. se brinda user and pass
            _Comando = new SqlCommand();


        }
        //metodo para pasarle las consultas
        public void setQuery(string query)
        {
            _Comando.CommandType = System.Data.CommandType.Text;// le decimos que el tipo de comando que vamos a usar es un texto
            _Comando.CommandText = query; // se lo asignamos al comando

        }

        public void ejecutarLectura()
        {
            _Comando.Connection = _Conexion; // le decimos que la conexion que vamos a usar es la que instanciamos en el constructor
            try
            {
                _Conexion.Open();
                _Lector = _Comando.ExecuteReader(); // ejecutamos la consulta
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public void ejecutarAccion()
        {
            _Comando.Connection = _Conexion;
            try
            {
                _Conexion.Open();
                _Comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void cerrarConexion()
        {
            if (Lector != null) // tambien puedo usar  _Conexion.State == System.Data.ConnectionState.Open o ambas!
                _Conexion.Close();
        }

         public void setParametro(string name ,object value) // tipo clave valor = un nombre y un object que representa el valor que recibe dado que puede ser distintos tipos
        {
            _Comando.Parameters.AddWithValue(name, value);
        }
    }
}
