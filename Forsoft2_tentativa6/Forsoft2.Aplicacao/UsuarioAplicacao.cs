using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using Forsoft2.Repositório;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forsoft2.Dominio;

namespace Forsoft2.Aplicacao
{
    public class UsuarioAplicacao
    {
        private Contexto contexto;

        private void Inserir(Usuario usuario)
        {
            var strQuery = "";
            strQuery += " INSERT INTO USUARIO (login, permissao) ";
            strQuery += string.Format(" VALUES ('{0}','{1}');",
                usuario.Login,
                usuario.Permissao);
            strQuery += "SELECT CAST(LAST_INSERT_ID() AS UNSIGNED)";

            int i = 0;
            using (contexto = new Contexto())
            {
                i = contexto.ExecutaComandoINT(strQuery);
            }

            string a = "null";
            var strQuery2 = "";
            strQuery2 += " INSERT INTO PESSOA (nome, email, equipe, pais, qualificacao, atribuicao, idusuario) ";
            strQuery2 += string.Format(" VALUES ('{0}','{1}', {2},'{3}','{4}','{5}',{6})",
                usuario.Nome,
                usuario.Email,
                usuario.Equipe.idEquipe,
                usuario.Pais,
                usuario.Qualificacao,
                usuario.Atribuicao,
                i);
            //insert into pessoa(nome, email, equipe, pais, qualificacao, atribuicao, idusuario) values('Luan', 'Luan@staff.com', null, 'Brasil', 'Especialista de Som', 'S', 1);

            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery2);
            }

        }

        private void Alterar(Usuario usuario)
        {
            var strQuery = "";
            strQuery += " update pessoa inner join usuario on pessoa.idusuario = usuario.id ";
                strQuery += "SET";
            strQuery += string.Format(" nome = '{0}',", usuario.Nome);
            strQuery += string.Format(" email = '{0}',", usuario.Email);
            strQuery += string.Format(" login = '{0}',", usuario.Login);
            strQuery += string.Format(" pais = '{0}',", usuario.Pais);
            strQuery += string.Format(" qualificacao = '{0}',", usuario.Qualificacao);
            strQuery += string.Format(" atribuicao = '{0}',", usuario.Atribuicao);
            strQuery += string.Format(" equipe = '{0}',", usuario.Equipe.idEquipe);
            strQuery += string.Format(" permissao = '{0}'", usuario.Permissao);
            strQuery += string.Format(" WHERE pessoa.id = '{0}'", usuario.idPessoa);

            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }

        public void Salvar(Usuario usuario)
        {
            if (usuario.idPessoa > 0)
                Alterar(usuario);
             else
                Inserir(usuario);
            
        }

        public void Excluir(int id)
        {
            using(contexto = new Contexto())
            {
                var strQuery = string.Format(" DELETE FROM PESSOA WHERE id = {0}", id);
                contexto.ExecutaComando(strQuery);
            }
        }

        public List<Usuario> ListarTodos()
        {
            using (contexto = new Contexto())
            {
                //var strQuery = "select usuario.login, " + 
                //    "usuario.permissao, pessoa.* ,"
                //    +"equipe.nome as 'equipenome', equipe.id as 'equipeid'"
                //    +"from pessoa,equipe inner join usuario "
                //    +"where pessoa.idusuario = usuario.id "
                //    +"group by pessoa.id";
                var strQuery = "select usuario.login, usuario.permissao, pessoa.* , equipe.nome as 'equipenome', equipe.id as 'equipeid' from pessoa inner join usuario on usuario.id = pessoa.idusuario inner join equipe on equipe.id = pessoa.equipe group by pessoa.id";
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListadeObjeto(retornoDataReader);
            }
        }

        public Usuario ListarPorID(int id)
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format("select usuario.login, usuario.permissao, pessoa.* , equipe.nome as 'equipenome', equipe.id as 'equipeid' from pessoa inner join usuario on usuario.id = pessoa.idusuario inner join equipe on equipe.id = pessoa.equipe where pessoa.id = {0} group by pessoa.id", id);
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListadeObjeto(retornoDataReader).FirstOrDefault();
            }
        }

        private List<Usuario> TransformaReaderEmListadeObjeto(MySqlDataReader reader)
        {
            var usuarios = new List<Usuario>();
            while (reader.Read())
            {
                var temObjeto = new Usuario()
                {
                    idPessoa = int.Parse(reader["id"].ToString()),
                    //idUsuario = int.Parse(reader["idusuario"].ToString()),
                    Nome = reader["nome"].ToString(),
                    Email = reader["email"].ToString(),
                    Permissao = Convert.ToInt32(reader["permissao"].ToString()),
                    Atribuicao = Convert.ToChar(reader["atribuicao"].ToString()),
                    Login = reader["login"].ToString(),
                    Pais = reader["pais"].ToString(),
                    Qualificacao = reader["qualificacao"].ToString(),

                    //Eventos = ListarTodosEventosPorUsuario(int.Parse(reader["idUsuario"].ToString()))
                    Equipe = new Equipe()
                    {
                        Nome = reader["equipenome"].ToString(),
                        idEquipe = Convert.ToInt32(reader["equipeid"].ToString())
                    }
                    
                };
                usuarios.Add(temObjeto);
            }

            reader.Close();
            return usuarios;
        }

        #region block
        //public List<Evento> ListarTodosEventosPorUsuario(int id)
        //{
        //    using (contexto = new Contexto())
        //    {
        //        var strQuery = string.Format("SELECT * FROM _USUARIOEVENTO_ WHERE idUsuario = {0}",id);
        //        var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
        //        return TransformaReaderEmListadeObjetoEV(retornoDataReader);
        //    }
        //}

        //private List<Evento> TransformaReaderEmListadeObjetoEV(MySqlDataReader reader)
        //{
        //    var eventos = new List<Evento>();
        //    while (reader.Read())
        //    {
        //        var temObjeto = new Evento()
        //        {
        //            idEvento = int.Parse(reader["idEvento"].ToString()),
        //            Nome = reader["nome"].ToString(),
        //        };
        //        eventos.Add(temObjeto);
        //    }

        //    reader.Close();
        //    return eventos;
        //}
        #endregion
    }
}
