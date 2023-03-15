﻿// <auto-generated />
using System;
using Facesign.Services.Infra.Data.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Facesign.Services.Infra.Data.Migrations
{
    [DbContext(typeof(SqlServerContext))]
    [Migration("20230208210817_ClientsConfs")]
    partial class ClientsConfs
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Facesign.Services.Infra.Data.Data.Client.Clients_Confs_FunctionalitiesData", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<bool>("authenticate_cnh")
                        .HasColumnType("bit");

                    b.Property<DateTime>("date_insert")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("date_insert")
                        .HasDefaultValueSql("getdate()");

                    b.Property<Guid>("id_conf")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id_conf");

                    b.Property<bool>("liveness_3d")
                        .HasColumnType("bit");

                    b.Property<bool>("match_3d")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.HasIndex("id_conf");

                    b.ToTable("clients_confs_functionalities");
                });

            modelBuilder.Entity("Facesign.Services.Infra.Data.Data.Client.Clients_Confs_LayoutsData", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTime>("date_insert")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("date_insert")
                        .HasDefaultValueSql("getdate()");

                    b.Property<byte[]>("home_image")
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("home_image");

                    b.Property<byte[]>("icon")
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("icon");

                    b.Property<Guid>("id_conf")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id_conf");

                    b.Property<string>("primary_color")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("primary_color");

                    b.Property<string>("secundary_color")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("secundary_color");

                    b.HasKey("id");

                    b.HasIndex("id_conf");

                    b.ToTable("clients_confs_layouts");
                });

            modelBuilder.Entity("Facesign.Services.Infra.Data.Data.Client.Clients_ConfsData", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTime>("date_insert")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("date_insert")
                        .HasDefaultValueSql("getdate()");

                    b.Property<Guid>("id_client")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id_client");

                    b.Property<string>("name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.HasKey("id");

                    b.HasIndex("id_client");

                    b.ToTable("clients_confs");
                });

            modelBuilder.Entity("Facesign.Services.Infra.Data.Data.Client.ClientsData", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("cpf")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("cpf");

                    b.Property<DateTime>("date_insert")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("date_insert")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("deviceModel")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("deviceModel");

                    b.Property<string>("externaldatabaserefid")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("externaldatabaserefid");

                    b.Property<string>("ip")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ip");

                    b.Property<string>("location")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("location");

                    b.Property<int?>("matchLevel")
                        .HasColumnType("int")
                        .HasColumnName("matchLevel");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("name");

                    b.Property<int?>("status")
                        .HasColumnType("int")
                        .HasColumnName("status");

                    b.Property<string>("telephone")
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)")
                        .HasColumnName("telephone");

                    b.Property<DateTime?>("validate")
                        .HasColumnType("datetime2")
                        .HasColumnName("validate");

                    b.HasKey("id");

                    b.ToTable("clients");
                });

            modelBuilder.Entity("Facesign.Services.Infra.Data.Data.Signature.SignaturesData", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("cpf")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("cpf");

                    b.Property<DateTime?>("dataSignature")
                        .HasColumnType("datetime2")
                        .HasColumnName("dataSignature");

                    b.Property<DateTime>("date_insert")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("date_insert")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("deviceModel")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("deviceModel");

                    b.Property<byte[]>("image")
                        .HasMaxLength(13)
                        .HasColumnType("varbinary(13)")
                        .HasColumnName("image");

                    b.Property<string>("ip")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ip");

                    b.Property<string>("location")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("location");

                    b.Property<int?>("matchLevel")
                        .HasColumnType("int")
                        .HasColumnName("matchLevel");

                    b.Property<string>("name")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("name");

                    b.Property<int>("status")
                        .HasColumnType("int")
                        .HasColumnName("status");

                    b.Property<DateTime>("validate")
                        .HasColumnType("datetime2")
                        .HasColumnName("validate");

                    b.HasKey("id");

                    b.ToTable("Signatures");
                });

            modelBuilder.Entity("Facesign.Services.Infra.Data.Data.Client.Clients_Confs_FunctionalitiesData", b =>
                {
                    b.HasOne("Facesign.Services.Infra.Data.Data.Client.Clients_ConfsData", "conf")
                        .WithMany()
                        .HasForeignKey("id_conf")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("conf");
                });

            modelBuilder.Entity("Facesign.Services.Infra.Data.Data.Client.Clients_Confs_LayoutsData", b =>
                {
                    b.HasOne("Facesign.Services.Infra.Data.Data.Client.Clients_ConfsData", "conf")
                        .WithMany()
                        .HasForeignKey("id_conf")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("conf");
                });

            modelBuilder.Entity("Facesign.Services.Infra.Data.Data.Client.Clients_ConfsData", b =>
                {
                    b.HasOne("Facesign.Services.Infra.Data.Data.Client.ClientsData", "client")
                        .WithMany()
                        .HasForeignKey("id_client")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("client");
                });
#pragma warning restore 612, 618
        }
    }
}
