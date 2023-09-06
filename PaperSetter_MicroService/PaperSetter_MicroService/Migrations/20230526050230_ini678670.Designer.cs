﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PaperSetter_MicroService.Models;

#nullable disable

namespace PaperSetter_MicroService.Migrations
{
    [DbContext(typeof(PaperSetterDbContext))]
    [Migration("20230526050230_ini678670")]
    partial class ini678670
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PaperSetter_MicroService.Models.Exam", b =>
                {
                    b.Property<int>("ExamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ExamName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Exam_Duration")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Exam_EndDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Exam_StartDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("QuestionBankId")
                        .HasColumnType("int");

                    b.HasKey("ExamId");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("PaperSetter_MicroService.Models.PaperSetter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ConfirmPassword")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("PaperSetter");
                });

            modelBuilder.Entity("PaperSetter_MicroService.Models.QuestionBank", b =>
                {
                    b.Property<int>("QuestionBankId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("QuestionBankName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.HasKey("QuestionBankId");

                    b.ToTable("QuestionBank");
                });

            modelBuilder.Entity("PaperSetter_MicroService.Models.Questions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CorrectAnswer")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Option1")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Option2")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Option3")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Option4")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("QuestionBankId")
                        .HasColumnType("int");

                    b.Property<string>("QuestionName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("QuestionBankId");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("PaperSetter_MicroService.Models.Questions", b =>
                {
                    b.HasOne("PaperSetter_MicroService.Models.QuestionBank", null)
                        .WithMany("Questions")
                        .HasForeignKey("QuestionBankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PaperSetter_MicroService.Models.QuestionBank", b =>
                {
                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
