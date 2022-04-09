using System.Text;
using System.Security.Cryptography;
using System.Collections.Generic;
using System;
using Titulacion.Models;

namespace Titulacion.Clases
{
    public class General
    {
        private static string boleta;

        public string Boleta { get => boleta; set => boleta = value; }

        public static string cifrarDatos(string data)
        {
            if (!string.IsNullOrEmpty(data))
            {
                SHA256Managed sha = new SHA256Managed();
                byte[] dataSinCifrar = Encoding.Default.GetBytes(data);
                byte[] dataCifrada = sha.ComputeHash(dataSinCifrar);
                return BitConverter.ToString(dataCifrada).Replace("-", "");
            }
            return "";
        }
        public static string Folio(Alumno alumno) {
            Random rd = new Random();
            string[] auxS = { alumno.Nombre, alumno.ApellidoPat, alumno.ApellidoMat };
            string folio = auxS[0].Substring(0, 2).ToUpper();
            folio += auxS[1].Substring(0, 2).ToUpper();
            folio += auxS[2].Substring(0, 2).ToUpper();
            folio += Convert.ToChar(rd.Next(65, 90));
            folio += rd.Next(0, 9);
            folio += Convert.ToChar(rd.Next(97, 122));
            return folio;
        }
    }
}
