using Forsoft2.Dominio;
using Forsoft2.Repositório;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Forsoft2.Aplicacao
{
    public class AtletaAplicacao
    {
        private Contexto contexto;

        private void Inserir(Atleta atleta)
        {
            var strQuery = "";
            strQuery += " INSERT INTO _ATLETA_ (nome, email, equipe) ";
            strQuery += string.Format(" VALUES ('{0}','{1}','{2}')",
                atleta.Nome,
                atleta.Email,
                atleta.Equipe);
                
            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }

        private void Alterar(Atleta atleta)
        {
            var strQuery = "";
            strQuery += " UPDATE _ATLETA_ SET";
            strQuery += string.Format(" nome = '{0}'", atleta.Nome);
            strQuery += string.Format(" email = '{0}'", atleta.Email);
            strQuery += string.Format(" equipe = '{0}'", atleta.Equipe);
            strQuery += string.Format(" WHERE id = '{0}'", atleta.idAtleta);
        }

        public void Salvar(Atleta atleta)
        {
            if (atleta.idAtleta > 0)
                Alterar(atleta);
            else
                Inserir(atleta);
        }

        public void Excluir(int id)
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format(" DELETE FROM ATLETA WHERE idAtleta = {0}", id);
                contexto.ExecutaComando(strQuery);
            }
        }

        public List<Atleta> ListarTodos()
        {
            using (contexto = new Contexto())
            {
                var strQuery = "SELECT * FROM ATLETA";
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListadeObjeto(retornoDataReader);
            }
        }

        public List<Atleta> ListarTodosEventosPorUsuario(int id)
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format("SELECT * FROM _EVENTOATLETA_ WHERE idEvento = {0}", id);
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListadeObjeto(retornoDataReader);
            }
        }

        private List<Atleta> TransformaReaderEmListadeObjeto(MySqlDataReader reader)
        {
            var atletas = new List<Atleta>();
            while (reader.Read())
            {
                var temObjeto = new Atleta()
                {
                    idAtleta = int.Parse(reader["id"].ToString()),
                    Nome = reader["nome"].ToString(),
                    Email = reader["email"].ToString()
                    //Equipe = reader["equipe"].ToString() Preciso testar ncoisas
                };
                atletas.Add(temObjeto);
            }
            reader.Close();
            return atletas;
        }
    }
}
