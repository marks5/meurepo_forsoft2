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
    class RecursoAplicacao
    {
        private Contexto contexto;

        private void Inserir(Recurso recurso)
        {
            var strQuery = "";
            strQuery += " INSERT INTO RECURSO (nome, disponibilidade, descricao) ";
            strQuery += string.Format(" VALUES ('{0}','{1}','{2}')", 
                recurso.Nome, 
                recurso.Disponibilidade, 
                recurso.Descricao);

            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }

        }

        private void Alterar(Recurso recurso)
        {
            var strQuery = "";
            strQuery += " UPDATE RECURSO SET";
            strQuery += string.Format(" nome = '{0}',", recurso.Nome);
            strQuery += string.Format(" disponibilidade = '{0}',", recurso.Disponibilidade);
            strQuery += string.Format(" descricao = '{0}' ", recurso.Descricao);
            strQuery += string.Format(" WHERE idRecurso = '{0}'", recurso.idRecurso);

            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }

        public void Salvar(Recurso recurso)
        {
            if (usuario.idUsuario > 0)
                Alterar(usuario);
            else
                Inserir(usuario);

        }

        public void Excluir(int id)
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format(" DELETE FROM RECURSO WHERE idRecurso = {0}", 
                    id);
                contexto.ExecutaComando(strQuery);
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
                    idRecurso = int.Parse(reader["idRecurso"].ToString()),
                    Nome = reader["nome"].ToString(),
                    Disponibilidade = Convert.ToInt32(reader["disponibilidade"].ToString()),
                    Descricao = reader["descricao"].ToString()
                };
                recursos.Add(temObjeto);
            }

            reader.Close();
            return recursos;
        }
    }
}
