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


                    string comandoSQL = "SELECT p.nome AS projeto, a.descricao AS atividade " +
                                        "FROM tabela_projetos p " +
                                        "JOIN tabela_atividades a ON p.projeto_id = a.projeto_id";


                    using (OdbcCommand command = new OdbcCommand(comandoSQL, connection))
                    {

                        using (OdbcDataReader reader = command.ExecuteReader())
                        {

                            if (reader.HasRows)
                            {
                                Console.WriteLine("Projetos e suas atividades:");

                                while (reader.Read())
                                {
                                    string projeto = reader["projeto"].ToString();
                                    string atividade = reader["atividade"].ToString();
                                    Console.WriteLine($"Projeto: {projeto}, Atividade: {atividade}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Não há projetos ou atividades cadastrados.");
                            }
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
