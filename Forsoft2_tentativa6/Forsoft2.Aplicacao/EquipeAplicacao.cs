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
    public class EquipeAplicacao
    {
        private Contexto contexto;

        public List<Equipe> ListarTodos()
        {
            using (contexto = new Contexto())
            {
                var strQuery = "SELECT * FROM EQUIPE";
                var retorno = contexto.ExecutaComandoComRetorno(strQuery);
                return RetornoDeLista(retorno);
            }
        }

        private List<Equipe> RetornoDeLista(MySqlDataReader reader)
        {
            var lista = new List<Equipe>();
            while (reader.Read())
            {
                var novaEquipe = new Equipe()
                {
                    idEquipe = Convert.ToInt32(reader["id"].ToString()),
                    Nome = reader["nome"].ToString()
                };
                lista.Add(novaEquipe);

            }
            reader.Close();
            return lista;
        }
    }
}
