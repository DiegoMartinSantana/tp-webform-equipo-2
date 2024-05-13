using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
namespace Negocio
{
    public class ArticuloGestion
    {
        public void Add(Articulo Art) // Agregar Articulo
        {
            AccesoBd Acceso = new AccesoBd();

            try
            {
                Acceso.setQuery("INSERT INTO ARTICULOS (Codigo,Nombre,Descripcion,IdMarca,IdCategoria,Precio)  VALUES (@cod,@nombre,@desc,@idm,@idc,@precio)");
                Acceso.setParametro("@cod", Art.Codigo);
                Acceso.setParametro("@nombre", Art.Nombre);
                Acceso.setParametro("@desc", Art.Descripcion);
                Acceso.setParametro("@idm", Art.Marca.Id);
                Acceso.setParametro("@idc", Art.Categoria.Id);
                Acceso.setParametro("@precio", Art.Precio);
                //insertamos articulo 
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
        public void Modificar(Articulo Art) // Modifica Articulo
        {
            AccesoBd Acceso = new AccesoBd();

            try
            {
				Acceso.setQuery("UPDATE ARTICULOS set Codigo = @cod, Nombre =@nombre, Descripcion = @desc, IdMarca = @idm, IdCategoria =@idc, Precio=@precio WHERE Id=@id");

                Acceso.setParametro("@cod", Art.Codigo);
				Acceso.setParametro("@nombre",Art.Nombre);
                Acceso.setParametro("@desc",Art.Descripcion);
                Acceso.setParametro("@idm",Art.Marca.Id);
                Acceso.setParametro("@idc",Art.Categoria.Id);
				Acceso.setParametro("@precio",Art.Precio);
				Acceso.setParametro("@id",Art.Id);
                //inssercion
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

        public List<Articulo> Listado() // Listar de Articulos
        {
            AccesoBd Acceso = new AccesoBd();

            var ListaArt = new List<Articulo>();
            try
            {

                Acceso.setQuery(" SELECT A.ID,A.CODIGO,A.NOMBRE,A.Descripcion,A.IdMarca,M.Descripcion MarcaDesc , A.IdCategoria,C.Descripcion CatDesc ,A.Precio FROM ARTICULOS AS A INNER JOIN MARCAS AS M ON M.Id = A.IdMarca INNER JOIN CATEGORIAS AS C ON C.Id = A.IdCategoria ");
                Acceso.ejecutarLectura();

                while (Acceso.Lector.Read())
                {
                    var Art = new Articulo();
                    Art.Id = (int)Acceso.Lector["Id"];
                    Art.Codigo = (string)Acceso.Lector["Codigo"];
                    Art.Nombre = (string)Acceso.Lector["Nombre"];
                    Art.Descripcion = (string)Acceso.Lector["Descripcion"];
                    //Genero la instancia de la Marca porque es un obj de mi clase Art
                    Art.Marca = new Marca();
                    Art.Marca.Id = (int)Acceso.Lector["IdMarca"];
                    Art.Marca.Descripcion = (string)Acceso.Lector["MarcaDesc"];
                    Art.Categoria = new Categoria();
                    Art.Categoria.Id = (int)Acceso.Lector["IdCategoria"];
                    Art.Categoria.Descripcion = (string)Acceso.Lector["CatDesc"];
                    Art.Precio = (decimal)Acceso.Lector["Precio"];

                    ListaArt.Add(Art);
                }
                return ListaArt;
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

        public List<Articulo> FiltroCriterios(string campo, string criterio, string filtro) // Filtrar Articulos
        {

            var Acceso = new AccesoBd();
            try
            {
                string query = "SELECT A.ID,A.CODIGO,A.NOMBRE,A.Descripcion,A.IdMarca,M.Descripcion MarcaDesc , A.IdCategoria,C.Descripcion CatDesc ,A.Precio FROM ARTICULOS AS A INNER JOIN MARCAS AS M ON M.Id = A.IdMarca INNER JOIN CATEGORIAS AS C ON C.Id = A.IdCategoria ";

                query += " Where ";

                if (campo == "Precio")
                {
                    if (criterio == "Mayor a :")
                    {
                        query += " A.Precio > " + filtro;
                    }
                    else if (criterio == "Menor a :")
                    {
                        query += "A.Precio < " + filtro;
                    }
                    else
                    {
                        query += "A.Precio = " + filtro;
                    }
                }
                else
                {
                    if (criterio == "Contiene :")
                    {
                        if (campo == "Categoria")
                        {
                            query += " C.Descripcion LIKE '%" + filtro + "%' ";
                        }
                        else if (campo == "Marca")
                        {
                            query += " M.Descripcion LIKE '%" + filtro + "%' ";

                        }

                    }
                    else if (criterio == "Termina con :")
                    {
                        if (campo == "Categoria")
                        {
                            query += " C.Descripcion LIKE '%" + filtro + "'";
                        }
                        else if (campo == "Marca")
                        {
                            query += " M.Descripcion LIKE '%" + filtro + "'";

                        }
                    }
                    else
                    {
                        if (campo == "Categoria")
                        {
                            query += "C.Descripcion LIKE '" + filtro + "%'";
                        }
                        else if (campo == "Marca")
                        {
                            query += "M.Descripcion LIKE '" + filtro + "%'";

                        }
                    }

                }

                query += "ORDER BY A.Nombre";

                Acceso.setQuery(query);

                Acceso.ejecutarLectura();

                var list = new List<Articulo>();
                while (Acceso.Lector.Read())
                {

                    var aux = new Articulo();
                    aux.Id = (int)Acceso.Lector["Id"];
                    aux.Codigo = (string)Acceso.Lector["Codigo"];
                    aux.Nombre = (string)Acceso.Lector["Nombre"];
                    aux.Descripcion = (string)Acceso.Lector["Descripcion"];
                    aux.Precio = (decimal)Acceso.Lector["Precio"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)Acceso.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)Acceso.Lector["Catdesc"];
                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)Acceso.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)Acceso.Lector["Marcadesc"];


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
                Acceso.cerrarConexion();
            }

        }

        public void eliminar(int id) // Eliminacion fisica de Articulo
        {
            AccesoBd datos = new AccesoBd();

            try
            {
                datos.setQuery("DELETE FROM ARTICULOS WHERE Id = @Id");
                datos.setParametro("@Id",id);
                datos.ejecutarAccion();

                var imgGestion = new ImagenGestion();
                imgGestion.EliminarTodas(id);

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        public bool ExistenciaCodigo(string codigo)
        {
            AccesoBd acceso = new AccesoBd();

            try
            {
                acceso.setQuery("SELECT codigo FROM ARTICULOS WHERE Codigo = @cod");
                acceso.setParametro("@cod", codigo);
                acceso.ejecutarLectura();

                while (acceso.Lector.Read())
                {
                    string aux = (string)acceso.Lector["codigo"];
                    if (!string.IsNullOrEmpty(aux))
                    {
                        return true;
                    }
                }
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
               acceso.cerrarConexion();
            }
            return false;

        }
    }
}
