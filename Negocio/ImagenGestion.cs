using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
namespace Negocio
{
    public class ImagenGestion
    {
      
        public void Add(Imagen img)
        {
            var acceso = new AccesoBd();

            try
            {
                acceso.setQuery("INSERT INTO Imagenes (IdArticulo,ImagenUrl) VALUES (@IdArt, @Url)");
                acceso.setParametro("@IdArt", img.IdArticulo);
                acceso.setParametro("@Url", img.UrlImagen);

                acceso.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                acceso.cerrarConexion();
            }


        }
        public List<Imagen> Listado()
        {
            var list = new List<Imagen>();
            var acceso = new AccesoBd();
            try
            {
                acceso.setQuery("SELECT Id,IdArticulo,ImagenUrl FROM Imagenes");

                acceso.ejecutarLectura();

                while (acceso.Lector.Read())
                {
                    var aux = new Imagen();
                    aux.Id = (int)acceso.Lector["Id"]; ;
                    aux.IdArticulo = (int)acceso.Lector["IdArticulo"];
                    aux.UrlImagen = (string)acceso.Lector["ImagenUrl"];
                    list.Add(aux);

                }
                return list;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                acceso.cerrarConexion();
            }
        }

        public List<Imagen> ListByIdArticulo(int idart)
        {
            var list = new List<Imagen>();
            var acceso = new AccesoBd();
            try
            {
                acceso.setQuery("SELECT Id,IdArticulo,ImagenUrl FROM Imagenes WHERE IdArticulo = @IdArt");
                acceso.setParametro("@IdArt", idart);

                acceso.ejecutarLectura();

                while (acceso.Lector.Read())
                {
                    var aux = new Imagen();
                    aux.Id = (int)acceso.Lector["Id"]; ;
                    aux.IdArticulo = (int)acceso.Lector["IdArticulo"];
                    aux.UrlImagen = (string)acceso.Lector["ImagenUrl"];
                    list.Add(aux);

                }
                return list;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                acceso.cerrarConexion();
            }


        }
        public void EliminarTodas(int idart)
        {
            var acceso = new AccesoBd();

            try
            {
                acceso.setQuery("DELETE  FROM Imagenes WHERE IdArticulo = @IdArt ");

                acceso.setParametro("@IdArt", idart);

                acceso.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                acceso.cerrarConexion();
            }

        }
        public void Eliminar(Imagen img)
        {
            var acceso = new AccesoBd();

            try
            {
                acceso.setQuery("DELETE  FROM Imagenes WHERE IdArticulo = @IdArt and ImagenUrl = @Url");

                acceso.setParametro("@IdArt", img.IdArticulo);
                acceso.setParametro("@Url", img.UrlImagen);

                acceso.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                acceso.cerrarConexion();
            }

        }
    }
}
