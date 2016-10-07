using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Contexto : IDisposable
    {
        private readonly MySqlConnection minhaConexao;

        public Contexto()
        {
            minhaConexao = 
                new MySqlConnection(ConfigurationManager.ConnectionStrings["Teste"].ConnectionString
                );
            minhaConexao.Open();
        }

        public void ExecutaComando(string strQuery)
        {
            var cmdComando = new MySqlCommand
            {
                CommandText = strQuery,
                CommandType = CommandType.Text,
                Connection = minhaConexao
            };

            cmdComando.ExecuteNonQuery();
        }

        public MySqlDataReader ExecutaComandoComRetorno(string strQuery)
        {
            var cmdComando = new MySqlCommand(strQuery, minhaConexao);
            return cmdComando.ExecuteReader();
        }

        public void Dispose()
        {
            if (minhaConexao.State == ConnectionState.Open)
                minhaConexao.Close();
        }
    }
}
