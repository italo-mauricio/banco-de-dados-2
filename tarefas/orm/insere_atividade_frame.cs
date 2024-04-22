using System;
using Microsoft.EntityFrameworkCore;

namespace AtividadesBD.Models
{
    public class Atividade
    {
        public int Id { get; set; }
        public int ProjetoId { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}


namespace AtividadesBD.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Atividade> Atividades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Driver={PostgreSQL Unicode};Server=localhost;Port=5432;Database=AtividadesBD;Uid=postgres;Pwd=teste12;");
        }
    }
}

using System;

namespace AtividadesBD
{
    class Program
    {
        static void Main(string[] args)
        {
            // Criar uma nova atividade
            var novaAtividade = new Atividade
            {
                ProjetoId = 1, 
                Descricao = "Descrição da atividade",
                DataInicio = DateTime.Now,
                DataFim = DateTime.Now.AddDays(1)
            };

            // Adicionar a nova atividade ao banco de dados
            using (var context = new AppDbContext())
            {
                context.Atividades.Add(novaAtividade);
                context.SaveChanges();
            }

            Console.WriteLine("Atividade inserida com sucesso!");
        }
    }
}

