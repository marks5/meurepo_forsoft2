using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Teste3.Models
{
    public class Evento
    {
        public int idEvento { get; set; }
        public string Nome { get; set; }
        public IEnumerable<Recurso> Recursos { get; set; }
        public Local Local { get; set; }
        public IEnumerable<Equipe> Equipes { get; set; }
        public Modalidade Modalidade { get; set; }
        public IEnumerable<Atleta> Atletas { get; set; }
    }
}