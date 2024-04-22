using System;
using System.Data;
using System.Data.Odbc;

namespace AcessoBancoDados
{
    class Program
    {
        static void Main(string[] args)
        {

            string connectionString = "Driver={PostgreSQL Unicode};Server=localhost;Port=5432;Database=AtividadesBD;Uid=italo;Pwd=teste123;";

            using (OdbcConnection connection = new OdbcConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Conexão bem-sucedida!");
                    DataTable schema = connection.GetSchema("Tables");
                    Console.WriteLine("Tabelas disponíveis:");
                    foreach (DataRow row in schema.Rows)
                    {
                        string tableName = row["TABLE_NAME"].ToString();
                        Console.WriteLine(tableName);
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


// para compilar e executar: 

//dotnet new console -n AcessoBancoDados
//cd AcessoBancoDados
//dotnet add package System.Data.Odbc
//dotnet run
