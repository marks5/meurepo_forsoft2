using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forsoft2.Dominio
{
    public class Evento
    {
        public int idEvento { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public Local Local { get; set; }
        public Modalidade Modalidade { get; set; }
    }
}