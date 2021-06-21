﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nibo.ConciliatorOFX.Data;

namespace Nibo.ConciliatorOFX.Data.Migrations
{
    [DbContext(typeof(ConciliatorOFXContext))]
    partial class ConciliatorOFXContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Nibo.ConciliatorOFX.Domain.Entities.BankAccount", b =>
                {
                    b.Property<int>("BankAccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AccountId")
                        .HasColumnType("bigint");

                    b.Property<int>("AccountType")
                        .HasColumnType("int");

                    b.Property<int>("BankId")
                        .HasColumnType("int");

                    b.HasKey("BankAccountId");

                    b.ToTable("BankAccounts");
                });

            modelBuilder.Entity("Nibo.ConciliatorOFX.Domain.Entities.BankStatement", b =>
                {
                    b.Property<int>("BankStatementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BankAccountId")
                        .HasColumnType("int");

                    b.Property<int>("BankTransactionsListId")
                        .HasColumnType("int");

                    b.Property<string>("Currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LedgerBalanceAggregateId")
                        .HasColumnType("int");

                    b.HasKey("BankStatementId");

                    b.HasIndex("BankAccountId");

                    b.HasIndex("BankTransactionsListId");

                    b.HasIndex("LedgerBalanceAggregateId");

                    b.ToTable("BankStatements");
                });

            modelBuilder.Entity("Nibo.ConciliatorOFX.Domain.Entities.BankTransaction", b =>
                {
                    b.Property<int>("BankTransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("BankTransactionsListId")
                        .HasColumnType("int");

                    b.Property<string>("Memo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PostedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TransactionType")
                        .HasColumnType("int");

                    b.HasKey("BankTransactionId");

                    b.HasIndex("BankTransactionsListId");

                    b.ToTable("BankTransactions");
                });

            modelBuilder.Entity("Nibo.ConciliatorOFX.Domain.Entities.BankTransactionsList", b =>
                {
                    b.Property<int>("BankTransactionsListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("BankTransactionsListId");

                    b.ToTable("BankTransactionsLists");
                });

            modelBuilder.Entity("Nibo.ConciliatorOFX.Domain.Entities.LedgerBalanceAggregate", b =>
                {
                    b.Property<int>("LedgerBalanceAggregateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.HasKey("LedgerBalanceAggregateId");

                    b.ToTable("LedgerBalanceAggregates");
                });

            modelBuilder.Entity("Nibo.ConciliatorOFX.Domain.Entities.BankStatement", b =>
                {
                    b.HasOne("Nibo.ConciliatorOFX.Domain.Entities.BankAccount", "BankAccount")
                        .WithMany()
                        .HasForeignKey("BankAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Nibo.ConciliatorOFX.Domain.Entities.BankTransactionsList", "BankTransactionsList")
                        .WithMany()
                        .HasForeignKey("BankTransactionsListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Nibo.ConciliatorOFX.Domain.Entities.LedgerBalanceAggregate", "LedgerBalanceAggregate")
                        .WithMany()
                        .HasForeignKey("LedgerBalanceAggregateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BankAccount");

                    b.Navigation("BankTransactionsList");

                    b.Navigation("LedgerBalanceAggregate");
                });

            modelBuilder.Entity("Nibo.ConciliatorOFX.Domain.Entities.BankTransaction", b =>
                {
                    b.HasOne("Nibo.ConciliatorOFX.Domain.Entities.BankTransactionsList", null)
                        .WithMany("BankTransactions")
                        .HasForeignKey("BankTransactionsListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Nibo.ConciliatorOFX.Domain.Entities.BankTransactionsList", b =>
                {
                    b.Navigation("BankTransactions");
                });
#pragma warning restore 612, 618
        }
    }
}
