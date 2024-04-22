using System;
using System.Linq;
using AtividadesBD.Models;

namespace AtividadesBD
{
    class Program
    {
        static void Main(string[] args)
        {
            // Consultar todos os projetos com suas atividades
            using (var context = new AppDbContext())
            {
                var projetosComAtividades = context.Projetos.Include(p => p.Atividades).ToList();

                if (projetosComAtividades.Any())
                {
                    Console.WriteLine("Projetos e suas atividades:");

                    // Iterar sobre cada projeto
                    foreach (var projeto in projetosComAtividades)
                    {
                        Console.WriteLine($"Projeto: {projeto.Nome}");

                        // Iterar sobre as atividades do projeto
                        foreach (var atividade in projeto.Atividades)
                        {
                            Console.WriteLine($"  Atividade: {atividade.Descricao}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Não há projetos ou atividades cadastrados.");
                }
            }
        }
    }
}
