using ABMProductos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{

   

    public class CategoriaGestion
    {


        public void Editar(Categoria catEdit)
        {
            var Acceso = new AccesoBd();

            try
            {
                Acceso.setQuery("UPDATE CATEGORIAS SET Descripcion = @desc WHERE Id = @id");
                Acceso.setParametro("@desc", catEdit.Descripcion);
                Acceso.setParametro("@id", catEdit.Id);
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
        public void Eliminar(int id)
        {
            var Acceso = new AccesoBd();

            try
            {
                Acceso.setQuery("DELETE FROM Categorias where Id = @id");
                Acceso.setParametro("id", id);
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

        public bool ExistenciaArticulos( int idCategoria)
        {
            var Acceso = new AccesoBd();

            try
            {
                Acceso.setQuery("SELECT TOP(1) Nombre FROM Articulos WHERE IdCategoria = @IdCat"); // con que exista uno ya alcanza para no permitir borrar
                Acceso.setParametro("IdCat", idCategoria);


                Acceso.ejecutarLectura();

                while (Acceso.Lector.Read())
                {
                    string aux = (string) Acceso.Lector["Nombre"];
                    if (!string.IsNullOrEmpty(aux))
                    {
                        return false;
                    }
                }

                return true;


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

        public void Add(Categoria categoria)
        {
            var Acceso = new AccesoBd();


            try
            {
                Acceso.setQuery("INSERT INTO Categorias (Descripcion) VALUES (@cat)");
                Acceso.setParametro("@cat", categoria.Descripcion);
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
        public List<Categoria> Listado()
        {
            var Lista = new List<Categoria>();

            AccesoBd Acceso = new AccesoBd();

            try
            {
                Acceso.setQuery("SELECT Id,Descripcion FROM Categorias");
                Acceso.ejecutarLectura();

                while (Acceso.Lector.Read())
                {
                    var aux = new Categoria();
                    aux.Id = (int)Acceso.Lector["Id"];
                    aux.Descripcion = (string)Acceso.Lector["Descripcion"];
                    Lista.Add(aux);

                }


                return Lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }finally {
                Acceso.cerrarConexion();
            }    


        }


    }
}
