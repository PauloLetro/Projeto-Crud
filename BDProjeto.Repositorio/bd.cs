using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BDProjeto.Repositorio
{
    //A classe precisa ser pública para ser chamada por outro projeto
   public class bd : IDisposable
    {
        //Método readonly faz com que a variável só sirva para leitura. A variável conexao do tipo readonly só vai servir para executar o banco de dados não podendo receber nem um valor que altere sua função
        private readonly SqlConnection conexao;
        //Construtor que é executado toda vez que a classe é chamada
        public bd()
        {
            //ConfigurationManager é para acessar ao arquivo de configfuração app.config
            //Caso não reconheça o ConfigurationManager, é só adicionar referência System.Configuration 
            conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["conexaoBD"].ConnectionString);
            conexao.Open();
        }



        public void ExecutaComando(string strQuery)
        {
            var cmdComando = new SqlCommand
            {
                //Preciso passar com o commandText pra ela entender que o strQuery é do tipo texto
                CommandText = strQuery,
                //Quando o valor é CommandType.Text, a propriedade CommandText deve conter o texto de uma consulta que deve ser executada no servidor.
                CommandType = CommandType.Text,
                Connection = conexao

            };
            cmdComando.ExecuteNonQuery();
        }


        public SqlDataReader ExecutaComandoComRetorno(string strQuery)
        {
            var cmdComandoSelect = new SqlCommand(strQuery, conexao);
            return cmdComandoSelect.ExecuteReader();
        }



        //O Idisposable força a execução do método Dispose().
        //Com o metodo Dispose vamos garantir de sempre fechar a conexão.
        public void Dispose()
        {
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }

        }
    }
}
