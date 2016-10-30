using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Xml.Serialization;
using System.Web;

namespace Forsoft2_tentativa6.Models
{
    public class RSA
    {
        public RSAParameters privKey { get; set; }
        public RSAParameters pubKey { get; set; }
        public RSA()
        {
            var csp = new RSACryptoServiceProvider(2048);
            //how to get the private key
            this.privKey = csp.ExportParameters(true);

            //and the public key ...
            this.pubKey = csp.ExportParameters(false);
        }

        public string pubKeyString(){
        //we need some buffer
        StringWriter sw = new StringWriter();
        //we need a serializer
        XmlSerializer xs = new XmlSerializer(typeof(RSAParameters));
        //serialize the key into the stream
        xs.Serialize(sw, this.pubKey);
        //get the string from the stream
        return sw.ToString();
      }




}
}