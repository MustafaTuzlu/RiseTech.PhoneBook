﻿using Contact.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System;

namespace RiseTech.Data.Migration
{
    [DbContext(typeof(PhoneBookContext))]
    partial class ContactContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("RiseTech.Data.Entities.Info", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer")
                    .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                b.Property<string>("Email")
                    .HasColumnType("text");

                b.Property<string>("Location")
                    .HasColumnType("text");

                b.Property<int?>("PersonId")
                    .HasColumnType("integer");

                b.Property<string>("Telephone")
                    .HasColumnType("text");

                b.HasKey("Id");

                b.HasIndex("PersonId");

                b.ToTable("Info");
            });
            modelBuilder.Entity("RiseTech.Data.Entities.Person", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer")
                    .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                b.Property<string>("Company")
                    .HasColumnType("text");

                b.Property<string>("Name")
                    .HasColumnType("text");

                b.Property<string>("Surname")
                    .HasColumnType("text");

                b.HasKey("Id");

                b.ToTable("People");
            });
            modelBuilder.Entity("RiseTech.Data.Entities.Report", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer")
                    .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                b.Property<DateTime>("Date")
                    .HasColumnType("timestamp without time zone");

                b.Property<string>("Detail")
                    .HasColumnType("text");

                b.Property<int>("Status")
                    .HasColumnType("integer");

                b.HasKey("Id");

                b.ToTable("Reports");
            });

            modelBuilder.Entity("RiseTech.Data.Entities.Info", b =>
            {
                b.HasOne("RiseTech.Data.Entities.Person", "Person")
                    .WithMany("Info")
                    .HasForeignKey("PersonId");

                b.Navigation("Person");
            });
            modelBuilder.Entity("RiseTech.Data.Entities.Person", b =>
            {
                b.Navigation("Info");
            });
        }
    }
}
