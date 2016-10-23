using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forsoft2.Dominio
{
    public class Atleta
    {
        public int idAtleta { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public Equipe Equipe { get; set; }
    }
}