using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace tcc20.Models
{
    public partial class tccContext : DbContext
    {
        public tccContext()
        {
        }

        public tccContext(DbContextOptions<tccContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbCartaoPagamento> TbCartaoPagamento { get; set; }
        public virtual DbSet<TbCliente> TbCliente { get; set; }
        public virtual DbSet<TbFilme> TbFilme { get; set; }
        public virtual DbSet<TbIngresso> TbIngresso { get; set; }
        public virtual DbSet<TbPedido> TbPedido { get; set; }
        public virtual DbSet<TbSala> TbSala { get; set; }
        public virtual DbSet<TbSalaFilme> TbSalaFilme { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;user id=root;password=123456;database=tcc", x => x.ServerVersion("8.0.19-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbCartaoPagamento>(entity =>
            {
                entity.HasKey(e => e.IdCartao)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdCliente)
                    .HasName("id_cliente");

                entity.Property(e => e.NmTitularCartao)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NrCartao)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NrCpfDoTitular)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.TbCartaoPagamento)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("tb_cartao_pagamento_ibfk_1");
            });

            modelBuilder.Entity<TbCliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PRIMARY");

                entity.Property(e => e.DsCidade)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsEmail)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsEstado)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsSenha)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NmCliente)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NrCpf)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NrTelefone)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<TbFilme>(entity =>
            {
                entity.HasKey(e => e.IdFilme)
                    .HasName("PRIMARY");

                entity.Property(e => e.DsClassificacaoIndicativa)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsDirecao)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsElenco)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsGenero)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsSinopse)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsTrailer)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ImgCartaz)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NmFilme)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<TbIngresso>(entity =>
            {
                entity.HasKey(e => e.IdIngresso)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdPedido)
                    .HasName("id_pedido");

                entity.Property(e => e.TpIngresso)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.TbIngresso)
                    .HasForeignKey(d => d.IdPedido)
                    .HasConstraintName("tb_ingresso_ibfk_1");
            });

            modelBuilder.Entity<TbPedido>(entity =>
            {
                entity.HasKey(e => e.IdPedido)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdCartao)
                    .HasName("id_cartao");

                entity.HasIndex(e => e.IdCliente)
                    .HasName("id_cliente");

                entity.HasIndex(e => e.IdSalaFilme)
                    .HasName("id_sala_filme");

                entity.Property(e => e.DsNotaFiscal)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdCartaoNavigation)
                    .WithMany(p => p.TbPedido)
                    .HasForeignKey(d => d.IdCartao)
                    .HasConstraintName("tb_pedido_ibfk_3");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.TbPedido)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("tb_pedido_ibfk_1");

                entity.HasOne(d => d.IdSalaFilmeNavigation)
                    .WithMany(p => p.TbPedido)
                    .HasForeignKey(d => d.IdSalaFilme)
                    .HasConstraintName("tb_pedido_ibfk_2");
            });

            modelBuilder.Entity<TbSala>(entity =>
            {
                entity.HasKey(e => e.IdSala)
                    .HasName("PRIMARY");

                entity.Property(e => e.NmSala)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.TpSala)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<TbSalaFilme>(entity =>
            {
                entity.HasKey(e => e.IdSalaFilme)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdFilme)
                    .HasName("id_filme");

                entity.HasIndex(e => e.IdSala)
                    .HasName("id_sala");

                entity.HasOne(d => d.IdFilmeNavigation)
                    .WithMany(p => p.TbSalaFilme)
                    .HasForeignKey(d => d.IdFilme)
                    .HasConstraintName("tb_sala_filme_ibfk_2");

                entity.HasOne(d => d.IdSalaNavigation)
                    .WithMany(p => p.TbSalaFilme)
                    .HasForeignKey(d => d.IdSala)
                    .HasConstraintName("tb_sala_filme_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
