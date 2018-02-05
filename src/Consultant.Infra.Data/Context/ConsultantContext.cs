using Consultant.Domain.Models;
using Consultant.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Consultant.Infra.Data.Context
{
    public class ConsultantContext : DbContext
    {

        public DbSet<Teste> Testes { get; set; }
        public DbSet<Apontamentos> Apontamentos { get; set; }
        public DbSet<Apontamentosfatura> Apontamentosfatura { get; set; }
        public DbSet<Atividades> Atividades { get; set; }
        public DbSet<Avaliacao> Avaliacao { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Clientesusuarios> Clientesusuarios { get; set; }
        public DbSet<Consultores> Consultores { get; set; }
        public DbSet<Consultoreshabilidades> Consultoreshabilidades { get; set; }
        public DbSet<Consultoresusuarios> Consultoresusuarios { get; set; }
        public DbSet<Faturas> Faturas { get; set; }
        public DbSet<Gerentes> Gerentes { get; set; }
        public DbSet<Gerentesusuarios> Gerentesusuarios { get; set; }
        public DbSet<Habilidades> Habilidades { get; set; }
        public DbSet<Precos> Precos { get; set; }
        public DbSet<Projetos> Projetos { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TesteMap());

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Apontamentos>(entity =>
            {
                entity.HasKey(e => e.IdApontamento);

                entity.ToTable("apontamentos");

                entity.HasIndex(e => e.IdAtividade)
                    .HasName("Atividades_idAtividade_ap");

                entity.Property(e => e.IdApontamento).HasColumnName("idApontamento");

                entity.Property(e => e.DatFim)
                    .HasColumnName("datFim")
                    .HasColumnType("datetime");

                entity.Property(e => e.DatInicio)
                    .HasColumnName("datInicio")
                    .HasColumnType("datetime");

                entity.Property(e => e.DatRegistro)
                    .HasColumnName("datRegistro")
                    .HasColumnType("datetime");

                entity.Property(e => e.DesRegistro)
                    .HasColumnName("desRegistro")
                    .HasMaxLength(200);

                entity.Property(e => e.IdAtividade).HasColumnName("idAtividade");

                entity.Property(e => e.IdConsultor).HasColumnName("idConsultor");

                entity.HasOne(d => d.IdAtividadeNavigation)
                    .WithMany(p => p.Apontamentos)
                    .HasForeignKey(d => d.IdAtividade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Atividades_idAtividade_ap");
            });

            modelBuilder.Entity<Apontamentosfatura>(entity =>
            {
                entity.HasKey(e => e.IdApontamentoFatura);

                entity.ToTable("apontamentosfatura");

                entity.HasIndex(e => e.IdApontamento)
                    .HasName("Apontamentos_idApontamento_ap");

                entity.HasIndex(e => e.IdFatura)
                    .HasName("FATURAS_idFatura_ap");

                entity.Property(e => e.IdApontamentoFatura).HasColumnName("idApontamentoFatura");

                entity.Property(e => e.DatRegistro).HasColumnName("datRegistro");

                entity.Property(e => e.IdApontamento).HasColumnName("idApontamento");

                entity.Property(e => e.IdFatura).HasColumnName("idFatura");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.NumValorApontamento).HasColumnName("numValorApontamento");

                entity.HasOne(d => d.IdApontamentoNavigation)
                    .WithMany(p => p.Apontamentosfatura)
                    .HasForeignKey(d => d.IdApontamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Apontamentos_idApontamento_ap");

                entity.HasOne(d => d.IdFaturaNavigation)
                    .WithMany(p => p.Apontamentosfatura)
                    .HasForeignKey(d => d.IdFatura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FATURAS_idFatura_ap");
            });

            modelBuilder.Entity<Atividades>(entity =>
            {
                entity.HasKey(e => e.IdAtividade);

                entity.ToTable("atividades");

                entity.HasIndex(e => e.IdProjeto)
                    .HasName("Projetos_idProjeto_at");

                entity.Property(e => e.IdAtividade).HasColumnName("idAtividade");

                entity.Property(e => e.DatAlteracao)
                    .HasColumnName("datAlteracao")
                    .HasColumnType("datetime");

                entity.Property(e => e.DatRegistro)
                    .HasColumnName("datRegistro")
                    .HasColumnType("datetime");

                entity.Property(e => e.DesAtividade)
                    .HasColumnName("desAtividade")
                    .HasMaxLength(500);

                entity.Property(e => e.DesTitulo)
                    .HasColumnName("desTitulo")
                    .HasMaxLength(50);

                entity.Property(e => e.IdProjeto).HasColumnName("idProjeto");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdProjetoNavigation)
                    .WithMany(p => p.Atividades)
                    .HasForeignKey(d => d.IdProjeto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Projetos_idProjeto_at");
            });

            modelBuilder.Entity<Avaliacao>(entity =>
            {
                entity.HasKey(e => e.IdAvaliacao);

                entity.ToTable("avaliacao");

                entity.HasIndex(e => e.IdCliente)
                    .HasName("Clientes_idCliente_ava");

                entity.HasIndex(e => e.IdConsultor)
                    .HasName("Consultor_idConsultor_ava");

                entity.Property(e => e.IdAvaliacao).HasColumnName("idAvaliacao");

                entity.Property(e => e.DatAlteracao).HasColumnName("datAlteracao");

                entity.Property(e => e.DatRegistro).HasColumnName("datRegistro");

                entity.Property(e => e.DesAvaliacao)
                    .HasColumnName("desAvaliacao")
                    .HasMaxLength(200);

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.IdConsultor).HasColumnName("idConsultor");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.NumRating).HasColumnName("numRating");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Avaliacao)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("Clientes_idCliente_ava");

                entity.HasOne(d => d.IdConsultorNavigation)
                    .WithMany(p => p.Avaliacao)
                    .HasForeignKey(d => d.IdConsultor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Consultor_idConsultor_ava");
            });

            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.HasKey(e => e.IdCliente);

                entity.ToTable("clientes");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.DatAlteracao)
                    .HasColumnName("datAlteracao")
                    .HasColumnType("datetime");

                entity.Property(e => e.DatRegistro)
                    .HasColumnName("datRegistro")
                    .HasColumnType("datetime");

                entity.Property(e => e.DesCliente).HasColumnName("desCliente");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.NumCnpj).HasColumnName("numCnpj");
            });

            modelBuilder.Entity<Clientesusuarios>(entity =>
            {
                entity.HasKey(e => new { e.IdCliente, e.IdUsuarioCliente });

                entity.ToTable("clientesusuarios");

                entity.HasIndex(e => e.IdUsuarioCliente)
                    .HasName("Usuario_idUsuario_cusu");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.IdUsuarioCliente).HasColumnName("idUsuarioCliente");

                entity.Property(e => e.DatRegistro)
                    .HasColumnName("datRegistro")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdUsuarios).HasColumnName("idUsuarios");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Clientesusuarios)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Clientes_idCliente_cusu");

                entity.HasOne(d => d.IdUsuarioClienteNavigation)
                    .WithMany(p => p.Clientesusuarios)
                    .HasForeignKey(d => d.IdUsuarioCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Usuario_idUsuario_cusu");
            });

            modelBuilder.Entity<Consultores>(entity =>
            {
                entity.HasKey(e => e.IdConsultor);

                entity.ToTable("consultores");

                entity.Property(e => e.IdConsultor).HasColumnName("idConsultor");

                entity.Property(e => e.DatAlteracao)
                    .HasColumnName("datAlteracao")
                    .HasColumnType("datetime");

                entity.Property(e => e.DatRegistro)
                    .HasColumnName("datRegistro")
                    .HasColumnType("datetime");

                entity.Property(e => e.DesConsultor).HasColumnName("desConsultor");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            });

            modelBuilder.Entity<Consultoreshabilidades>(entity =>
            {
                entity.HasKey(e => new { e.IdConsultor, e.IdHabilidades });

                entity.ToTable("consultoreshabilidades");

                entity.HasIndex(e => e.IdHabilidades)
                    .HasName("Habilidades_ch");

                entity.Property(e => e.IdConsultor).HasColumnName("idConsultor");

                entity.Property(e => e.IdHabilidades).HasColumnName("idHabilidades");

                entity.Property(e => e.DatRegistro)
                    .HasColumnName("datRegistro")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdConsultorNavigation)
                    .WithMany(p => p.Consultoreshabilidades)
                    .HasForeignKey(d => d.IdConsultor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Consultores_idConsultor_ch");

                entity.HasOne(d => d.IdHabilidadesNavigation)
                    .WithMany(p => p.Consultoreshabilidades)
                    .HasForeignKey(d => d.IdHabilidades)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Habilidades_ch");
            });

            modelBuilder.Entity<Consultoresusuarios>(entity =>
            {
                entity.HasKey(e => new { e.IdConsultor, e.IdUsuarioConsultor });

                entity.ToTable("consultoresusuarios");

                entity.HasIndex(e => e.IdUsuarioConsultor)
                    .HasName("Usuario_idUsuario_cu");

                entity.Property(e => e.IdConsultor).HasColumnName("idConsultor");

                entity.Property(e => e.IdUsuarioConsultor).HasColumnName("idUsuarioConsultor");

                entity.Property(e => e.DatRegistro)
                    .HasColumnName("datRegistro")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdConsultorNavigation)
                    .WithMany(p => p.Consultoresusuarios)
                    .HasForeignKey(d => d.IdConsultor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Consultores_idConsultor_cu");

                entity.HasOne(d => d.IdUsuarioConsultorNavigation)
                    .WithMany(p => p.Consultoresusuarios)
                    .HasForeignKey(d => d.IdUsuarioConsultor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Usuario_idUsuario_cu");
            });

            modelBuilder.Entity<Faturas>(entity =>
            {
                entity.HasKey(e => e.IdFatura);

                entity.ToTable("faturas");

                entity.HasIndex(e => e.IdCliente)
                    .HasName("Clientes_idCliente_fr");

                entity.HasIndex(e => e.IdConsultor)
                    .HasName("Consultores_idConsultor_fr");

                entity.HasIndex(e => e.IdProjeto)
                    .HasName("Projetos_idProjeto_fr");

                entity.Property(e => e.IdFatura).HasColumnName("idFatura");

                entity.Property(e => e.DatAlteracao)
                    .HasColumnName("datAlteracao")
                    .HasColumnType("datetime");

                entity.Property(e => e.DatRegistro)
                    .HasColumnName("datRegistro")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.IdConsultor).HasColumnName("idConsultor");

                entity.Property(e => e.IdProjeto).HasColumnName("idProjeto");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.NumValorTotal).HasColumnName("numValorTotal");

                entity.Property(e => e.SitFatura).HasColumnName("sitFatura");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Faturas)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Clientes_idCliente_fr");

                entity.HasOne(d => d.IdConsultorNavigation)
                    .WithMany(p => p.Faturas)
                    .HasForeignKey(d => d.IdConsultor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Consultores_idConsultor_fr");

                entity.HasOne(d => d.IdProjetoNavigation)
                    .WithMany(p => p.Faturas)
                    .HasForeignKey(d => d.IdProjeto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Projetos_idProjeto_fr");
            });

            modelBuilder.Entity<Gerentes>(entity =>
            {
                entity.HasKey(e => e.IdGerente);

                entity.ToTable("gerentes");

                entity.Property(e => e.IdGerente).HasColumnName("idGerente");

                entity.Property(e => e.DatAlteracao)
                    .HasColumnName("datAlteracao")
                    .HasColumnType("datetime");

                entity.Property(e => e.DatRegistro)
                    .HasColumnName("datRegistro")
                    .HasColumnType("datetime");

                entity.Property(e => e.DesGerente)
                    .HasColumnName("desGerente")
                    .HasMaxLength(100);

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            });

            modelBuilder.Entity<Gerentesusuarios>(entity =>
            {
                entity.HasKey(e => new { e.IdGerente, e.IdUsuarioGerente });

                entity.ToTable("gerentesusuarios");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("Usuario_idUsuario_GU");

                entity.Property(e => e.IdGerente).HasColumnName("idGerente");

                entity.Property(e => e.IdUsuarioGerente).HasColumnName("idUsuarioGerente");

                entity.Property(e => e.DatRegistro)
                    .HasColumnName("datRegistro")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdGerenteNavigation)
                    .WithMany(p => p.Gerentesusuarios)
                    .HasForeignKey(d => d.IdGerente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Gerentes_idGerente");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Gerentesusuarios)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("Usuario_idUsuario_GU");
            });

            modelBuilder.Entity<Habilidades>(entity =>
            {
                entity.HasKey(e => e.IdHabilidades);

                entity.ToTable("habilidades");

                entity.Property(e => e.IdHabilidades).HasColumnName("idHabilidades");

                entity.Property(e => e.DatRegistro)
                    .HasColumnName("datRegistro")
                    .HasColumnType("datetime");

                entity.Property(e => e.DesHabilidade).HasColumnName("desHabilidade");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            });

            modelBuilder.Entity<Precos>(entity =>
            {
                entity.HasKey(e => e.IdPreco);

                entity.ToTable("precos");

                entity.HasIndex(e => e.IdConsultor)
                    .HasName("Consultores_idConsultor_pr");

                entity.Property(e => e.IdPreco).HasColumnName("idPreco");

                entity.Property(e => e.DatAlteracao)
                    .HasColumnName("datAlteracao")
                    .HasColumnType("datetime");

                entity.Property(e => e.DatRegistro)
                    .HasColumnName("datRegistro")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdConsultor).HasColumnName("idConsultor");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.NumValorHora).HasColumnName("numValorHora");

                entity.HasOne(d => d.IdConsultorNavigation)
                    .WithMany(p => p.Precos)
                    .HasForeignKey(d => d.IdConsultor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Consultores_idConsultor_pr");
            });

            modelBuilder.Entity<Projetos>(entity =>
            {
                entity.HasKey(e => e.IdProjeto);

                entity.ToTable("projetos");

                entity.HasIndex(e => e.IdCliente)
                    .HasName("Clientes_idCliente_pr");

                entity.HasIndex(e => e.IdConsultor)
                    .HasName("Consultores_idConsultor_pro");

                entity.HasIndex(e => e.IdGerente)
                    .HasName("Gerentes_idGerente_pr");

                entity.Property(e => e.IdProjeto).HasColumnName("idProjeto");

                entity.Property(e => e.DatAlteracao)
                    .HasColumnName("datAlteracao")
                    .HasColumnType("datetime");

                entity.Property(e => e.DatConclusao)
                    .HasColumnName("datConclusao")
                    .HasColumnType("datetime");

                entity.Property(e => e.DatRegistro)
                    .HasColumnName("datRegistro")
                    .HasColumnType("datetime");

                entity.Property(e => e.DesProjeto).HasColumnName("desProjeto");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.IdConsultor).HasColumnName("idConsultor");

                entity.Property(e => e.IdGerente).HasColumnName("idGerente");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.NumTempoTotal).HasColumnName("numTempoTotal");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Projetos)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Clientes_idCliente_pr");

                entity.HasOne(d => d.IdConsultorNavigation)
                    .WithMany(p => p.Projetos)
                    .HasForeignKey(d => d.IdConsultor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Consultores_idConsultor_pro");

                entity.HasOne(d => d.IdGerenteNavigation)
                    .WithMany(p => p.Projetos)
                    .HasForeignKey(d => d.IdGerente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Gerentes_idGerente_pr");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.ToTable("usuarios");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.DatAlteracao)
                    .HasColumnName("datAlteracao")
                    .HasColumnType("datetime");

                entity.Property(e => e.DatRegistro)
                    .HasColumnName("datRegistro")
                    .HasColumnType("datetime");

                entity.Property(e => e.DesEmail)
                    .HasColumnName("desEmail")
                    .HasMaxLength(100);

                entity.Property(e => e.DesSenha)
                    .HasColumnName("desSenha")
                    .HasMaxLength(100);

                entity.Property(e => e.DesUsuario)
                    .HasColumnName("desUsuario")
                    .HasMaxLength(100);
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // define the database to use
            optionsBuilder.UseMySql(config.GetConnectionString("DefaultConnection"));
        }
    }
}
