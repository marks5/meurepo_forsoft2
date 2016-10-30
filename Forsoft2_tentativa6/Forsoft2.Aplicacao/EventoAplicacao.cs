using Forsoft2.Dominio;
using Forsoft2.Repositório;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forsoft2.Aplicacao
{
    public class EventoAplicacao
    {
        private Contexto contexto;

        public void Excluir(int id)
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format("DELETE FROM EVENTO WHERE id = {0}", id);
                contexto.ExecutaComando(strQuery);
            }
        }

        public Evento ListarPorID(int id)
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format("SELECT * FROM EVENTO WHERE id = {0}", id);
                var retorno = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListadeObjeto(retorno).FirstOrDefault();
            }
        }

        public List<Evento> ListarTodos()
        {
            using (contexto = new Contexto())
            {
                var strQuery = "SELECT * FROM EVENTO";
                var retorno = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListadeObjeto(retorno);
            }
        }

        public List<Evento> ListarAPI()
        {
            using (contexto = new Contexto())
            {
                var strQuery = "SELECT * FROM EVENTO";
                var retorno = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListadeObjetoAPI(retorno);
            }
        }

        private List<Evento> TransformaReaderEmListadeObjetoAPI(MySqlDataReader reader)
        {
            var eventos = new List<Evento>();
            while (reader.Read())
            {
                var objEvento = new Evento()
                {
                    idEvento = int.Parse(reader["id"].ToString()),
                    Nome = reader["nome"].ToString(),
                    Data = DateTime.Parse(reader["dataevento"].ToString())
                };
                eventos.Add(objEvento);
            }

            reader.Close();
            return eventos;
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
                    Data = DateTime.Parse(reader["dataevento"].ToString()),
                    Local = new Local()
                    {
                        idLocal = Convert.ToInt32(reader["localevento"].ToString())
                    },
                    Modalidade = new Modalidade()
                    {
                        idModalidade = Convert.ToInt32(reader["modalidade"].ToString())
                    }
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
