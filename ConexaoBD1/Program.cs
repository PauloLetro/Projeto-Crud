using BDProjeto.Aplicacao;
using BDProjeto.Dominio;

using System;
//Biblioteca para conexão com banco de  
using System.Data.SqlClient;

namespace DOS
{
    class Program
    {
        static void Main(string[] args)
        {

           
            var app = new UsuarioAplicacao();

            //Conexão ao banco de dados
            //Parametros: Local do banco de dados | Segurança para acesso ao bando de dados (usuários) SSPI quando o usuario for autenticado por Windowns | Nome do banco de dados
            SqlConnection conexao = new SqlConnection(@"data source= DESKTOP-PBFFRBK\SQLEXPRESS01; Integrated Security=SSPI; Initial Catalog=ExemploBD");

            //Iniciando a conexão
            conexao.Open();

          

            Console.WriteLine("Digite o nome do usuário: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o cargo do usuário: ");
            string cargo = Console.ReadLine();

            Console.WriteLine("Digite a data de cadastro do usuário: ");
            string data = Console.ReadLine();

            var usuarios = new Usuarios
            {
                Nome = nome,
                Cargo = cargo,
                Data = DateTime.Parse(data)
            };

            //usuarios.Id = 5;

            app.Salvar(usuarios);
           
            //string strQuerySelect = "SELECT * FROM usuarios";
           var dados = app.ListarTodos();
           foreach(var usuario in dados)
            {
                Console.WriteLine("Id:{0}, Nome:{1}, Cargo:{2}, Data:{3}", usuario.Id, usuario.Nome, usuario.Cargo, usuario.Data);
            }

            /*
            //Conexão ao banco de dados
            //Parametros: Local do banco de dados | Segurança para acesso ao bando de dados (usuários) SSPI quando o usuario for autenticado por Windowns | Nome do banco de dados
            SqlConnection conexao = new SqlConnection(@"data source= DESKTOP-PBFFRBK\SQLEXPRESS01; Integrated Security=SSPI; Initial Catalog=ExemploBD");

            //Iniciando a conexão
            conexao.Open();

            //------------------------------------------------------------------------------------------------------
            //                     UTILIZANDO UPDATE
            //Instrução SQL - Atualizar na minha tabela usuario na coluna nome com o novo nome Fabio onde o Id for igual a 1     
            //string strQueryUpdate = "UPDATE usuarios SET nome = 'Fabio' WHERE usuarioId = 1";

            //Para executar o comando SQL - Objeto do tipo sqlComamnd
            //Parametros: Instrução | Em qual Banco de dados deverá ser realizada a instrução.
            //SqlCommand cmdComandoUpdate = new SqlCommand(strQueryUpdate, conexao);

            //Executor de dados com DataReader para de fato executar o comando
            //A variável dados carrega a execução do cmdComandoSelect
            //Aqui executamos com ExecuteNoQuery pois ele não precisa retornar um valor
           // cmdComandoUpdate.ExecuteNonQuery();


            //------------------------------------------------------------------------------------------------------
            //                     UTILIZANDO Delete
            //Instrução SQL - Atualizar na minha tabela usuario na coluna nome com o novo nome Fabio onde o Id for igual a 1     
            string strQueryDelete = "DELETE FROM usuarios WHERE usuarioId=1";

            //Para executar o comando SQL - Objeto do tipo sqlComamnd
            //Parametros: Instrução | Em qual Banco de dados deverá ser realizada a instrução.
            SqlCommand cmdComandoDelete = new SqlCommand(strQueryDelete, conexao);

            //Executor de dados com DataReader para de fato executar o comando
            //A variável dados carrega a execução do cmdComandoSelect
            //Aqui executamos com ExecuteNoQuery pois ele não precisa retornar um valor
            cmdComandoDelete.ExecuteNonQuery();


            //------------------------------------------------------------------------------------------------------
            //                     UTILIZANDO Insert
            //Instrução SQL - Atualizar na minha tabela usuario na coluna nome com o novo nome Fabio onde o Id for igual a 1

            Console.WriteLine("Digite o nome do usuário");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o cargo do usuário");
            string cargo = Console.ReadLine();

            Console.WriteLine("Digite a data de cadastro do usuário");
            string data = Console.ReadLine();

            //O id não precisa passar pois ele incrementa automaticamente
            //Ao inserir valores utilizando o Comando Insert, podemos utilizar as chaves no VALUE, assim para passar os paramentros das chaves devemos usar o string.Format para formatar a string
            string strQueryInsert = string.Format("Insert INTO usuarios(nome, cargo, date) VALUES('{0}','{1}','{2}')", nome, cargo, data);

            //Para executar o comando SQL - Objeto do tipo sqlComamnd
            //Parametros: Instrução | Em qual Banco de dados deverá ser realizada a instrução.
            SqlCommand cmdComandoInsert = new SqlCommand(strQueryInsert, conexao);

            //Executor de dados com DataReader para de fato executar o comando
            //A variável dados carrega a execução do cmdComandoSelect
            //Aqui executamos com ExecuteNoQuery pois ele não precisa retornar um valor
            cmdComandoInsert.ExecuteNonQuery();


            //----------------------------------------------------------------------------------------------------
            //                      UTILIZANDO SELECT

            //Instrução SQL - Selecionar todos os registros da minha tabela usuário
            string strQuerySelect = "SELECT * FROM usuarios";

            //Para executar o comando SQL - Objeto do tipo sqlComamnd
            //Parametros: Instrução | Em qual Banco de dados deverá ser realizada a instrução.
            SqlCommand cmdComandoSelect = new SqlCommand(strQuerySelect, conexao);

            //Executor de dados com DataReader para de fato executar o comando
            //A variável dados carrega a execução do cmdComandoSelect
            //Aqui executamos com ExecuteReader pois ele esta retornando um valor
            SqlDataReader dados = cmdComandoSelect.ExecuteReader();

            //Fazer leitura dos dados enquanto houver dados
            while (dados.Read())
            {

                //As informações que são buscadas na tabela são entregues em forma de array, por isso dados[] é um array
               Console.WriteLine("Id:{0}, Nome:{1}, Cargo:{2}, Data:{3}", dados["usuarioId"], dados["nome"], dados["cargo"], dados["date"]);
            }

               */
        }

    }
}
