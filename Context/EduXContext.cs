using EduX_API.Domains;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace EduX_API.Context
{
    public class EduXContext : DbContext
    {
        //Contexto do db
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<ProfessorTurma> ProfessorTurma { get; set; }
        public DbSet<AlunoTurma> AlunoTurma { get; set; }
        public DbSet<Dica> Dica { get; set; }
        public DbSet<Perfil> Perfil { get; set; }
        public DbSet<Curtida> Curtida { get; set; }
        public DbSet<Objetivo> Objetivo { get; set; }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<ObjetivoAluno> ObjetivoAluno { get; set; }
        public DbSet<Instituicao> Instituicao { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Turma> Turma { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Data source=.\SQLEXPRESS;Initial Catalog=Db_EduX;user id=sa;password=sa132");
            base.OnConfiguring(optionsBuilder);
            

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dica>()
                .HasOne(d => d.Usuario)
                .WithMany();
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Perfil)
                .WithMany();

            modelBuilder.Entity<Curtida>()
                .HasOne(c => c.Usuario)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Curtida>()
                .HasOne(c => c.Dica)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ObjetivoAluno>()
                .HasOne(obj => obj.AlunoTurma)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ObjetivoAluno>()
                .HasOne(obj => obj.Turma)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
        }

    }
}

