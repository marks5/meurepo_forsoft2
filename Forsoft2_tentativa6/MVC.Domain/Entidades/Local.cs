using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forsoft2.Dominio
{
    public class Local
    {
        public int idLocal { get; set; }
        public string Nome { get; set; }
        public string Endereço { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }
    }
}