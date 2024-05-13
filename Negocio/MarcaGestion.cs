using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class MarcaGestion
    {
        public void Editar(Marca marcaEdit) // Modificar Marca
        {
            var Acceso = new AccesoBd();

            try
            {
                Acceso.setQuery("UPDATE MARCAS SET Descripcion = @desc WHERE Id = @id");
                Acceso.setParametro("id", marcaEdit.Id);
                Acceso.setParametro("desc", marcaEdit.Descripcion);
                Acceso.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                Acceso.cerrarConexion();
            }
        }

        public void Eliminar(int id) // Eliminar Marca
        {
            var Acceso = new AccesoBd();

            try
            {
                Acceso.setQuery("DELETE FROM Marcas where Id = @id");
                Acceso.setParametro("id", id);
                Acceso.ejecutarAccion();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Acceso.cerrarConexion();
            }
        }

        public bool ExistenciaArticulos(int idMarca) // Validar existencia de articulos con la Marca incorporada
        {
            var Acceso = new AccesoBd();

            try
            {
                Acceso.setQuery("SELECT TOP(1) Nombre FROM Articulos WHERE IdMarca = @idmarca"); // Con que exista uno ya alcanza para no permitir borrar
                Acceso.setParametro("idmarca", idMarca);
                Acceso.ejecutarLectura();

                // Verificar si el lector tiene alguna fila
                if (Acceso.Lector.HasRows)
                {
                    return true; // Hay al menos un artículo asociado a la marca
                }
                else
                {
                    return false; // No hay ningún artículo asociado a la marca
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                Acceso.cerrarConexion();
            }
        }

        public void Add(Marca marca) // Agregar Marca
        {
            var Acceso = new AccesoBd();


            try
            {
                Acceso.setQuery("INSERT INTO Marcas (Descripcion) VALUES (@desc)");
                Acceso.setParametro("@desc", marca.Descripcion);
                Acceso.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Acceso.cerrarConexion();
            }

        }

        public List<Marca> Listado() // Listar Marcas
        {
            var Acceso = new AccesoBd();

            var Lista = new List<Marca>();
            try
            {
                Acceso.setQuery("SELECT Id, Descripcion FROM Marcas");
                Acceso.ejecutarLectura();

                while (Acceso.Lector.Read())
                {
                    var aux = new Marca();
                    aux.Id = (int)Acceso.Lector["Id"];
                    aux.Descripcion = (string)Acceso.Lector["Descripcion"];

                    Lista.Add(aux);

                }
                return Lista;


            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Acceso.cerrarConexion();
            }

        }
    }
}
