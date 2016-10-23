using Forsoft2.Dominio;
using Forsoft2.Repositório;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forsoft2.Aplicacao
{
    class EventoAplicacao
    {
        private Contexto contexto;

        private void Inserir(Evento evento)
        {
            var strQuery = "";
            strQuery += " insert into _evento_ ";
            strQuery += " (nome, _local, modalidade, _data) ";
            strQuery += string.Format("Values ('{0}', '{1}', '{2}', '{3}');"
                , evento.Nome, evento.Local,evento.Modalidade,evento.Data);

            using(contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }

        private void Alterar(Evento evento)
        {
            var strQuery = "";
            strQuery += "";
        }

        public void Salvar(Evento evento)
        {
            if (evento.idEvento > 0)
                Alterar(evento);
            else
                Inserir(evento);
        }

        public void Excluir(int id)
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format("DELETE FROM _EVENTO_ WHERE id = {0}", id);
                contexto.ExecutaComando(strQuery);
            }
        }

        public Evento ListarPorID(int id)
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format("SELECT * FROM _EVENTO_ WHERE id = {0}", id);
                var retorno = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListadeObjeto(retorno).FirstOrDefault();
            }
        }

        public List<Evento> ListarTodos()
        {
            using (contexto = new Contexto())
            {
                var strQuery = "SELECT * FROM _EVENTO_";
                var retorno = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListadeObjeto(retorno);
            }
        }

        private List<Evento> TransformaReaderEmListadeObjeto(MySqlDataReader reader)
        {
            var eventos = new List<Evento>();
            while (reader.Read())
            {
                var objEvento = new Evento()
                {
                    idEvento = int.Parse(reader["id"].ToString()),
                    Nome = reader["nome"].ToString(),
                    Data = DateTime.Parse(reader["_data"].ToString()),
                    //Modalidade = 
                    //Atletas
                    //Equipes
                    //Local = reader[""]
                    //Recursos

                };
                eventos.Add(objEvento);
            }

            reader.Close();
            return eventos;
        }
    }
}
