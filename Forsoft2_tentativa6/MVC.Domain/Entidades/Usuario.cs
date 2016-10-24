using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forsoft2.Dominio
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public string Login { get; set; }
        public int Permissao { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public Equipe Equipe { get; set; }
        public string Pais { get; set; }
        public string Qualificacao { get; set; }
        public char Atribuicao { get; set; }
    }
}