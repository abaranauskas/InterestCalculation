using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using InterestCAlculation.Entities;

namespace InterestCAlculation.Migrations
{
    [DbContext(typeof(InterestCalculationDbContext))]
    [Migration("20181121160530_initial2")]
    partial class initial2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InterestCAlculation.Entities.Agreement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AgreementDuration");

                    b.Property<decimal>("Amount");

                    b.Property<decimal>("BaseRate");

                    b.Property<int>("BaseRateCode");

                    b.Property<int?>("CustomerId");

                    b.Property<decimal>("Margin");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Agreements");
                });

            modelBuilder.Entity("InterestCAlculation.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 25);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 25);

                    b.Property<string>("PersonalId")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 11);

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("InterestCAlculation.Entities.Agreement", b =>
                {
                    b.HasOne("InterestCAlculation.Entities.Customer", "Customer")
                        .WithMany("Agreements")
                        .HasForeignKey("CustomerId");
                });
        }
    }
}
