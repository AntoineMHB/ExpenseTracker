﻿// <auto-generated />
using System;
using ExpenseTracker.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExpenseTracker.Migrations
{
    [DbContext(typeof(ExpenseTrackerContext))]
    partial class ExpenseTrackerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ExpenseTracker.Model.Budget", b =>
                {
                    b.Property<int>("BudgetID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BudgetID"));

                    b.Property<string>("BudgetName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("BudgetID");

                    b.HasIndex("UserID");

                    b.ToTable("Budget");
                });

            modelBuilder.Entity("ExpenseTracker.Model.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"));

                    b.Property<decimal>("AllocatedAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("BudgetID")
                        .HasColumnType("int");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("CategoryID");

                    b.HasIndex("BudgetID");

                    b.HasIndex("UserID");

                    b.ToTable("ExpenseCategory");
                });

            modelBuilder.Entity("ExpenseTracker.Model.Expense", b =>
                {
                    b.Property<int>("ExpenseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExpenseID"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("BudgetID")
                        .HasColumnType("int");

                    b.Property<int?>("CategoryID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ExpenseID");

                    b.HasIndex("BudgetID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("UserID");

                    b.ToTable("Expense");
                });

            modelBuilder.Entity("ExpenseTracker.Model.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ExpenseTracker.Model.Budget", b =>
                {
                    b.HasOne("ExpenseTracker.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ExpenseTracker.Model.Category", b =>
                {
                    b.HasOne("ExpenseTracker.Model.Budget", "Budget")
                        .WithMany()
                        .HasForeignKey("BudgetID");

                    b.HasOne("ExpenseTracker.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Budget");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ExpenseTracker.Model.Expense", b =>
                {
                    b.HasOne("ExpenseTracker.Model.Budget", "Budget")
                        .WithMany()
                        .HasForeignKey("BudgetID");

                    b.HasOne("ExpenseTracker.Model.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID");

                    b.HasOne("ExpenseTracker.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Budget");

                    b.Navigation("Category");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
