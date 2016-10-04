﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Teste3.Models
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int Permissao { get; set; }
        public IEnumerable<Evento> Eventos { get; set; }
    }
}