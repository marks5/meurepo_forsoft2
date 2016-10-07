﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forsoft2.Dominio
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int Permissao { get; set; }
        public List<Evento> Eventos { get; set; }
    }
}