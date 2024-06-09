using System.Security.Cryptography;
using System.Text;

namespace MarketExpress.Helper
{
    public static class Cryptography
    {

        public static string GenerateHash(this string valor)
        {
            var hash = SHA1.Create();
            var encoding = new ASCIIEncoding();
            var array = encoding.GetBytes(valor);

            array = hash.ComputeHash(array);

            var srtHexa = new StringBuilder();

            foreach (var item in array) 
            {
                srtHexa.Append(item.ToString("x2"));

            }

            return srtHexa.ToString();
        }


    }
}
