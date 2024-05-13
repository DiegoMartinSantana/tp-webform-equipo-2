using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public static class Helper
    {
        public static string UrlImgFirst(int idArt)
        {
            var ImgGest = new ImagenGestion();
            var Url = ImgGest.ListByIdArticulo(idArt);
            


            if (Url != null && Url.Count != 0)
            {
                if (string.IsNullOrEmpty(Url.First().UrlImagen))
                {
                    return "https://ih1.redbubble.net/image.2289245086.4528/bg,f8f8f8-flat,750x,075,f-pad,750x1000,f8f8f8.jpg";
                }
                //caso donde si es valida y funciona
                return Url.First().UrlImagen;
            }
            return "https://ih1.redbubble.net/image.2289245086.4528/bg,f8f8f8-flat,750x,075,f-pad,750x1000,f8f8f8.jpg";

        }


    }
}
