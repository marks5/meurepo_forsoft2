using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Teste3.Models
{
    public class Equipe
    {
        public int idEquipe { get; set; }
        public string Nome { get; set; }
        public Modalidade Modalidade { get; set; }
        public List<Atleta> Atletas { get; set; }
    }
}