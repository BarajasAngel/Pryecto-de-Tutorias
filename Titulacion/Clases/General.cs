using System.Text;
using System.Security.Cryptography;
using System.Collections.Generic;
using System;

namespace Titulacion.Clases
{
    public class General
    {
        public static string cifrarDatos(string data)
        {
            SHA256Managed sha = new SHA256Managed();
            byte[] dataSinCifrar = Encoding.Default.GetBytes(data);
            byte[] dataCifrada = sha.ComputeHash(dataSinCifrar);

            return BitConverter.ToString(dataCifrada).Replace("-", "");
        }
    }
}
