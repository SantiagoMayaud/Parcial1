﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Parcial1SM.Data;

#nullable disable

namespace Parcial1SM.Migrations
{
    [DbContext(typeof(ModelKitContext))]
    [Migration("20230520171549_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("Parcial1SM.Models.ModelKit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Finished")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ModelMakerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Pieces")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ModelMakerId");

                    b.ToTable("ModelKit");
                });

            modelBuilder.Entity("Parcial1SM.Models.ModelMaker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BrandName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ModelMaker");
                });

            modelBuilder.Entity("Parcial1SM.Models.ModelKit", b =>
                {
                    b.HasOne("Parcial1SM.Models.ModelMaker", "ModelMaker")
                        .WithMany("ModelKits")
                        .HasForeignKey("ModelMakerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ModelMaker");
                });

            modelBuilder.Entity("Parcial1SM.Models.ModelMaker", b =>
                {
                    b.Navigation("ModelKits");
                });
#pragma warning restore 612, 618
        }
    }
}
