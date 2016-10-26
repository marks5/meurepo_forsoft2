using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forsoft2.Dominio;
using Forsoft2.Repositório;
using MySql.Data.MySqlClient;

namespace Forsoft2.Aplicacao
{
    public class RecursoAplicacao
    {
        private Contexto contexto;

        private void Inserir(Recurso recurso)
        {
            var strQuery = "";
            strQuery += " INSERT INTO RECURSO (nome, disponibilidade, descricao) ";
            strQuery += string.Format(" VALUES ('{0}',{1},'{2}')", 
                recurso.Nome, 
                recurso.Disponibilidade, 
                recurso.Descricao);

            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }

        }

        public List<Recurso> ListarPorIDEV(string idEvento)
        {
            throw new NotImplementedException();
        }

        public void Inserir(int idEvento, Recurso recurso)
        {
            var strQuery = "";
            strQuery += "";

            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }

        public Recurso ListarPorIDEV(int idEvento)
        {
            throw new NotImplementedException();
        }

        private void Alterar(Recurso recurso)
        {
            var strQuery = "";
            strQuery += " UPDATE RECURSO SET";
            strQuery += string.Format(" nome = '{0}',", recurso.Nome);
            strQuery += string.Format(" disponibilidade = {0},", recurso.Disponibilidade);
            strQuery += string.Format(" descricao = '{0}' ", recurso.Descricao);
            strQuery += string.Format(" WHERE id = '{0}'", recurso.idRecurso);

            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }

        public void Excluir(int idEvento, int id)
        {
            throw new NotImplementedException();
        }

        public void Salvar(Recurso recurso)
        {
            if (recurso.idRecurso > 0)
                Alterar(recurso);
            else
                Inserir(recurso);

        }

        public void Excluir(int id)
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format(" DELETE FROM RECURSO WHERE id = {0}", 
                    id);
                contexto.ExecutaComando(strQuery);
            }
        }

        public Recurso ListarPorID(int id)
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format("SELECT * FROM RECURSO WHERE id = {0}", id);
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListadeObjeto(retornoDataReader).FirstOrDefault();
            }
        }

        public List<Recurso> ListarTodos()
        {
            using (contexto = new Contexto())
            {
                var strQuery = "SELECT * FROM RECURSO";
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListadeObjeto(retornoDataReader);
            }
        }

        private List<Recurso> TransformaReaderEmListadeObjeto(MySqlDataReader reader)
        {
            var recursos = new List<Recurso>();
            while (reader.Read())
            {
                var temObjeto = new Recurso()
                {
                    idRecurso = int.Parse(reader["id"].ToString()),
                    Nome = reader["nome"].ToString(),
                    Disponibilidade = Convert.ToBoolean((reader["disponibilidade"].ToString())),
                    Descricao = reader["descricao"].ToString()
                };
                recursos.Add(temObjeto);
            }

            reader.Close();
            return recursos;
        }
    }
}
