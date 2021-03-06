﻿using Forsoft2.Dominio;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forsoft2.Aplicacao;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            var appUsuario = new UsuarioAplicacao();
            //string strQueryUpdate = "UPDATE USUARIOS SET email ='out232ro@teste.com' WHERE idUsuario = 1";
            //MySqlCommand cmdUpdate = new MySqlCommand(strQueryUpdate, minhaConexao);
            //cmdUpdate.ExecuteNonQuery();

            //string strQueryDelete = "DELETE FROM USUARIOS WHERE idUsuario = 1";
            //MySqlCommand cmdDelete = new MySqlCommand(strQueryDelete, minhaConexao);
            //cmdDelete.ExecuteNonQuery();



                        Console.WriteLine("Digite o email do usuario");
                        string email = Console.ReadLine();

                        Console.WriteLine("Digite a senha do usuario");
                        string senha = Console.ReadLine();

                        Console.WriteLine("Digite a permissao do usuario");
                        string permissao = Console.ReadLine();

                        var usuario1 = new Usuario
                        {
                            Email = email,
                            Permissao = Convert.ToInt32(permissao)
                        };

                        //usuario.idUsuario = 3;

                        appUsuario.
                            Salvar(usuario1);

            //string strQueryInsert = string.Format("INSERT INTO USUARIOS (email, senha, permissao) values ('{0}','{1}','{2}')",email,senha,permissao);

            //new UsuarioAplicacao().Excluir(4);

            //string strQuerySelect = "SELECT * FROM USUARIOS";
            //MySqlDataReader dados = contexto.ExecutaComandoComRetorno(strQuerySelect);

            var dados = appUsuario.ListarTodos();

            foreach (var usuario in dados)
            {
                Console.WriteLine("IdUsuario: {0}, Email: {1}, Permissao: {2}", usuario.idUsuario, usuario.Email, usuario.Permissao);
            }
                

        }
    }
}
