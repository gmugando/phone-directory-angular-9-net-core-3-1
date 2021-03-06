﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PhoneDirectory.Data;
using PhoneDirectory.Data.Persistence.Context;

namespace PhoneDirectory.Data.Migrations
{
    [DbContext(typeof(PhoneBookContext))]
    [Migration("20200503131919_InitialSetup")]
    partial class InitialSetup
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PhoneDirectory.Data.Entry", b =>
                {
                    b.Property<int>("EntryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneBookId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EntryId");

                    b.HasIndex("PhoneBookId");

                    b.ToTable("Entries");
                });

            modelBuilder.Entity("PhoneDirectory.Data.PhoneBook", b =>
                {
                    b.Property<int>("PhoneBookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PhoneBookName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PhoneBookId");

                    b.ToTable("PhoneBook");
                });

            modelBuilder.Entity("PhoneDirectory.Data.Entry", b =>
                {
                    b.HasOne("PhoneDirectory.Data.PhoneBook", "PhoneBook")
                        .WithMany("Entries")
                        .HasForeignKey("PhoneBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
