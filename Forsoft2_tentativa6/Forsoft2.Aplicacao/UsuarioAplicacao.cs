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
            strQuery += " INSERT INTO _USUARIO_ (nome, email, permissao) ";
            strQuery += string.Format(" VALUES ('{0}','{1}','{2}')",
                usuario.Nome,
                usuario.Email,
                usuario.Permissao);

            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }

        }

        private void Alterar(Usuario usuario)
        {
            var strQuery = "";
            strQuery += " UPDATE _USUARIO_ SET";
            strQuery += string.Format(" nome = '{0}',", usuario.Nome);
            strQuery += string.Format(" email = '{0}',", usuario.Email);
            strQuery += string.Format(" permissao = '{0}' ", usuario.Permissao);
            strQuery += string.Format(" WHERE id = '{0}'", usuario.idUsuario);

            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }

        public void Salvar(Usuario usuario)
        {
            if (usuario.idUsuario > 0)
                Alterar(usuario);
             else
                Inserir(usuario);
            
        }

        public void Excluir(int id)
        {
            using(contexto = new Contexto())
            {
                var strQuery = string.Format(" DELETE FROM _USUARIO_ WHERE id = {0}", id);
                contexto.ExecutaComando(strQuery);
            }
        }

        public List<Usuario> ListarTodos()
        {
            using (contexto = new Contexto())
            {
                var strQuery = "SELECT * FROM _USUARIO_";
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListadeObjeto(retornoDataReader);
            }
        }

        public Usuario ListarPorID(int id)
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format("SELECT * FROM _USUARIO_ WHERE id = {0}",id);
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
                    idUsuario = int.Parse(reader["id"].ToString()),
                    Nome = reader["nome"].ToString(),
                    Email = reader["email"].ToString(),
                    Permissao = Convert.ToInt32(reader["permissao"].ToString()),
                    //Eventos = ListarTodosEventosPorUsuario(int.Parse(reader["idUsuario"].ToString()))

                };
                usuarios.Add(temObjeto);
            }

            reader.Close();
            return usuarios;
        }

        public List<Evento> ListarTodosEventosPorUsuario(int id)
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format("SELECT * FROM _USUARIOEVENTO_ WHERE idUsuario = {0}",id);
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListadeObjetoEV(retornoDataReader);
            }
        }

        private List<Evento> TransformaReaderEmListadeObjetoEV(MySqlDataReader reader)
        {
            var eventos = new List<Evento>();
            while (reader.Read())
            {
                var temObjeto = new Evento()
                {
                    idEvento = int.Parse(reader["idEvento"].ToString()),
                    Nome = reader["nome"].ToString(),
                };
                eventos.Add(temObjeto);
            }

            reader.Close();
            return eventos;
        }
    }
}
