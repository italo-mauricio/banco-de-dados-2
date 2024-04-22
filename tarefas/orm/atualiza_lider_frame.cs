using System;
using System.Linq;
using AtividadesBD.Models;

namespace AtividadesBD
{
    class Program
    {
        static void Main(string[] args)
        {

            int projetoId = 1; 
            int novoLiderId = 1; 

            // Atualizar o líder do projeto
            using (var context = new AppDbContext())
            {
                // Localizar o projeto desejado
                var projeto = context.Projetos.FirstOrDefault(p => p.Id == projetoId);

                if (projeto != null)
                {
                    // Atualizar o ID do líder
                    projeto.LiderId = novoLiderId;

                    // Salvar as alterações no banco de dados
                    context.SaveChanges();

                    Console.WriteLine("Líder do projeto atualizado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Projeto não encontrado.");
                }
            }
        }
    }
}
