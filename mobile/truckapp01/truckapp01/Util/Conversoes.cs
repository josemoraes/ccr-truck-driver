using System;
using System.IO;
using Xamarin.Forms;

namespace truckapp01.Util
{
    public class Conversoes
    {
        public Conversoes()
        {
        }

        public static string ConvertImageToBase64(string url)
        {
            string fotoCodificada = "";

            try
            {
                FileStream fs = new FileStream(url, FileMode.Open, FileAccess.Read);
                byte[] ImageData = new byte[fs.Length];
                fs.Read(ImageData, 0, Convert.ToInt32(fs.Length));
                fs.Close();
                //float width = (int)DimensoesDeFotos.Largura;
                //float height = (int)DimensoesDeFotos.Altura;
                //int quality = 45;

                //byte[] ResizedImage = DependencyService.Get<IImageResizer>().ResizeImage(ImageData, width, height, quality);

                fotoCodificada = Convert.ToBase64String(ImageData);
            }
            catch (Exception error)
            {
                Console.WriteLine($"ERRO AO CONVERTER IMAGEM > {error.Message}");
            }

            return fotoCodificada;
        }

        public static ImageSource ConvertBase64ToImage(string base64Image)
        {
            var fotoByte = Convert.FromBase64String(base64Image);
            return ImageSource.FromStream(() => new MemoryStream(fotoByte));
        }

        public static string CpfFormat(string cpf)
        {
            return $"{cpf.Substring(0, 3)}.{ cpf.Substring(3, 3)}.{ cpf.Substring(6, 3)}-{ cpf.Substring(9, 2)}";
        }

        public static string CpfRemoveCaracteres(string cpf)
        {
            string valor = cpf.Replace(".", "");
            return valor.Replace("-", "");
        }
    }
}
