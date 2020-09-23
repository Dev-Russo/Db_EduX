using EduX_API.Domains;
using Microsoft.EntityFrameworkCore;

namespace EduX_API.Context
{
    public class EduXContext : DbContext
    {
        //Contexto do db
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<ProfessorTurma> ProfessorTurma { get; set; }
        public DbSet<AlunoTurma> AlunoTurma { get; set; }
        public DbSet<Dica> Dica { get; set; }
        public DbSet <Perfil> Perfil { get; set; }
        public DbSet <Curtida> Curtida { get; set; }
        public DbSet <Objetivo> Objetivo { get; set; }
        public DbSet <Curso> Curso { get; set; }
        public DbSet<ObjetivoAluno> ObjetivoAluno { get; set; }

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer(@"Data source=.\SQLEXPRESS;Initial Catalog=Db_EduX;user id=sa;password=sa132");

        object p = base.OnConfiguring(optionsBuilder);
    }
}

