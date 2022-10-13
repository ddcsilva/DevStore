﻿// <auto-generated />
using System;
using DevStore.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DevStore.Data.Mapping.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DevStore.Data.Domain.CategoriaProduto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("nome");

                    b.HasKey("Id")
                        .HasName("pk_categoria_produto");

                    b.ToTable("categoria_produto");
                });

            modelBuilder.Entity("DevStore.Data.Domain.Loja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("nome");

                    b.HasKey("Id")
                        .HasName("pk_loja");

                    b.ToTable("loja");
                });

            modelBuilder.Entity("DevStore.Data.Domain.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("descricao");

                    b.Property<int>("Garantia")
                        .HasPrecision(4)
                        .HasColumnType("int")
                        .HasColumnName("garantia");

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int")
                        .HasColumnName("id_categoria");

                    b.Property<int>("IdLoja")
                        .HasColumnType("int")
                        .HasColumnName("id_loja");

                    b.Property<string>("Imagens")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("imagens");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("nome");

                    b.Property<decimal>("Preco")
                        .HasPrecision(7, 2)
                        .HasColumnType("decimal(7,2)")
                        .HasColumnName("preco");

                    b.Property<int>("QuantidadeEstoque")
                        .HasPrecision(4)
                        .HasColumnType("int")
                        .HasColumnName("quantidade_estoque");

                    b.Property<int>("TipoGarantia")
                        .HasColumnType("int")
                        .HasColumnName("tipo_garantia");

                    b.HasKey("Id")
                        .HasName("pk_produto");

                    b.HasIndex("IdCategoria")
                        .HasDatabaseName("idx_produto_id_categoria");

                    b.HasIndex("IdLoja")
                        .HasDatabaseName("idx_produto_id_loja");

                    b.ToTable("produto");
                });

            modelBuilder.Entity("DevStore.Data.Domain.Produto", b =>
                {
                    b.HasOne("DevStore.Data.Domain.CategoriaProduto", "Categoria")
                        .WithMany()
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_produto_id_categoria");

                    b.HasOne("DevStore.Data.Domain.Loja", "Loja")
                        .WithMany()
                        .HasForeignKey("IdLoja")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_produto_id_loja");

                    b.Navigation("Categoria");

                    b.Navigation("Loja");
                });
#pragma warning restore 612, 618
        }
    }
}
