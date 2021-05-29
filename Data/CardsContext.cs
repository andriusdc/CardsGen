using Microsoft.EntityFrameworkCore;
using CardsAPI.Models;
using Microsoft.SqlServer.Server;

namespace CardsAPI.Data
{   //classe de contexto
    public class CardsContext : DbContext
    {
        //mapeamento de entidade p/ tabela
        public DbSet<Card> Card{get; set;}

        //provedor e string de conexao
        protected override void 
        OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=DbCardApi;Data Source=DESKTOP-F0N0EQ6\SQLEXPRESS");
    }
}