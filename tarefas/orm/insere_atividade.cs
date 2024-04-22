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

                    string comandoSQL = "INSERT INTO tabela_atividades (projeto_id, descricao, data_inicio, data_fim) VALUES (@projeto_id, @descricao, @data_inicio, @data_fim)";

                    using (OdbcCommand command = new OdbcCommand(comandoSQL, connection))
                    {

                        command.Parameters.AddWithValue("@projeto_id", 1);
                        command.Parameters.AddWithValue("@descricao", "Descrição da atividade");
                        command.Parameters.AddWithValue("@data_inicio", DateTime.Now);
                        command.Parameters.AddWithValue("@data_fim", DateTime.Now.AddDays(1));


                        int linhasAfetadas = command.ExecuteNonQuery();

                        if (linhasAfetadas > 0)
                        {
                            Console.WriteLine("Atividade inserida com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Nenhuma linha afetada. A inserção pode ter falhado.");
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
