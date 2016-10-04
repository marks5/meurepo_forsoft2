using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPNET.MVC.Models
{
    public class Md5
    {
        public string CriptografiaMD5(string Valor)
        {
            string strResultado = "";
            byte[] bytMensagem = System.Text.Encoding.Default.GetBytes(Valor);

            // Cria o Hash MD5 hash
            System.Security.Cryptography.MD5CryptoServiceProvider oMD5Provider = new System.Security.Cryptography.MD5CryptoServiceProvider();

            // Gera o Hash Code
            byte[] bytHashCode = oMD5Provider.ComputeHash(bytMensagem);
            for (int iItem = 0; iItem < bytHashCode.Length; iItem++)
            {
                strResultado += (char)(bytHashCode[iItem]);
            }
            return strResultado;
        }
    }
}