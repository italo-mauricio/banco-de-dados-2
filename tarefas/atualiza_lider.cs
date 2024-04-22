using System;
using System.Data;
using System.Data.Odbc;

namespace AcessoBancoDados
{
    class Program
    {
        static void Main(string[] args)
        {

            string connectionString = "Driver={PostgreSQL Unicode};Server=localhost;Port=5432;Database=AtividadesBD;Uid=postgres;Pwd=teste12;";

            using (OdbcConnection connection = new OdbcConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Conexão bem-sucedida!");

                    string comandoSQL = "UPDATE tabela_projetos SET lider_id = @novo_lider_id WHERE projeto_id = @projeto_id";

                    using (OdbcCommand command = new OdbcCommand(comandoSQL, connection))
                    {

                        command.Parameters.AddWithValue("@novo_lider_id", 1); 
                        command.Parameters.AddWithValue("@projeto_id", 1); 


                        int linhasAfetadas = command.ExecuteNonQuery();


                        if (linhasAfetadas > 0)
                        {
                            Console.WriteLine("Líder do projeto atualizado com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Nenhuma linha afetada. A atualização pode ter falhado.");
                        }
                    }
                }
                catch (OdbcException ex)
                {
                    Console.WriteLine("Erro ao conectar ou acessar o banco de dados:");
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
