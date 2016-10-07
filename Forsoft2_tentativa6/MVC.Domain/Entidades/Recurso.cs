using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forsoft2.Dominio
{
    public class Recurso
    {
        public int idRecurso { get; set; }
        public string Nome { get; set; }
        public bool Disponibilidade { get; set; }
        public string Descrição { get; set; }
    }
}