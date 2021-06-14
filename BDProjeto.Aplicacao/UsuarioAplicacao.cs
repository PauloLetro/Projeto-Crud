using BDProjeto.Dominio;
using BDProjeto.Repositorio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace BDProjeto.Aplicacao
{
    public class UsuarioAplicacao
    {
        //Variável que será associada a nossa classe bd
        private bd bd;

        //Não é desejado que os métodos Inserir e Alterar sejam chamados de fora da classe
        private void Inserir(Usuarios usuarios)
        {
            //Concatenando a nossa Query
            var strQuery = "";
            strQuery += "INSERT INTO usuarios(nome, cargo, date)";
            strQuery += string.Format(" VALUES ('{0}', '{1}', '{2}')", usuarios.Nome, usuarios.Cargo, usuarios.Data);

            //Executar a Quary com using, ele utiliza o que esta dentro dos parenteses e depois descarta
            //Assim ele vai instancia a classe bd e vai executar o construtor dentro dela abrindo conexão, e pelo fato de ter o Idiposable, ele tb força o fechamento da conexão.
            using (bd = new bd())
            {
                bd.ExecutaComando(strQuery);
            }

        }

        private void Alterar(Usuarios usuarios)
        {
            var strQuery = "";
            strQuery += "UPDATE usuarios SET ";
            strQuery += string.Format("nome = '{0}',", usuarios.Nome);
            strQuery += string.Format("cargo = '{0}',", usuarios.Cargo);
            strQuery += string.Format("date = '{0}' ", usuarios.Data);
            strQuery += string.Format("WHERE usuarioId = {0} ", usuarios.Id);

            using (bd = new bd())
            {
                bd.ExecutaComando(strQuery);
            }
        }


        public void Salvar(Usuarios usuarios)
        {
            if (usuarios.Id > 0)
            {
                Alterar(usuarios);
            }
            else
            {
                Inserir(usuarios);
            }
        }

        public void Excluir(int id)
        {
            using (bd = new bd())
            {
                var strQuery = string.Format("DELETE FROM usuarios WHERE usuarioId = {0}", id);
                bd.ExecutaComando(strQuery);
            }
        }


        public  List<Usuarios> ListarTodos()
        {
            using (bd = new bd())
            {
                var strQuery = "SELECT * FROM usuarios";

                var retorno = bd.ExecutaComandoComRetorno(strQuery);

                return ReaderEmLista(retorno);
            }
           
        }

        private List<Usuarios> ReaderEmLista(SqlDataReader reader)
        {
            var usuarios = new List<Usuarios>();
            while (reader.Read())
            {
                var tempoObjeto = new Usuarios()
                {
                    Id = int.Parse(reader["usuarioId"].ToString()),
                    Nome = reader["nome"].ToString(),
                    Cargo = reader["cargo"].ToString(),
                    Data = DateTime.Parse(reader["date"].ToString()),

                };

                usuarios.Add(tempoObjeto);
            }

            reader.Close();
            return usuarios;

        }


        public Usuarios ListarPorId(int id)
        {
            using (bd = new bd())
            {
                var strQuery = string.Format("SELECT * FROM usuarios WHERE usuarioId = {0}", id);

                var retorno = bd.ExecutaComandoComRetorno(strQuery);

                return ReaderEmLista(retorno).FirstOrDefault();
            }

        }

    }
}
