﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Teste3.Models
{
    public class Atleta
    {
        public int idAtleta { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Imagem { get; set; }
        public Equipe Equipe { get; set; }
        public Modalidade Modalidade { get; set; }

    }
}