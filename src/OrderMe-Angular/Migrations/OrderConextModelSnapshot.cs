using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using OrderMe_Angular.OMA.Models;

namespace OrderMeAngular.Migrations
{
    [DbContext(typeof(OrderConext))]
    partial class OrderConextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OrderMe_Angular.OMA.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("OrderLineId");

                    b.HasKey("OrderId");

                    b.HasIndex("OrderLineId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("OrderMe_Angular.OMA.Models.OrderLine", b =>
                {
                    b.Property<int>("OrderLineId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("qty");

                    b.HasKey("OrderLineId");

                    b.ToTable("OrderLines");
                });

            modelBuilder.Entity("OrderMe_Angular.OMA.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int?>("OrderLineId");

                    b.HasKey("ProductId");

                    b.HasIndex("OrderLineId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("OrderMe_Angular.OMA.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Name");

                    b.Property<int?>("OrderLineId");

                    b.HasKey("UserId");

                    b.HasIndex("OrderLineId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("OrderMe_Angular.OMA.Models.Order", b =>
                {
                    b.HasOne("OrderMe_Angular.OMA.Models.OrderLine", "OrderLine")
                        .WithMany("Orders")
                        .HasForeignKey("OrderLineId");
                });

            modelBuilder.Entity("OrderMe_Angular.OMA.Models.Product", b =>
                {
                    b.HasOne("OrderMe_Angular.OMA.Models.OrderLine", "OrderLine")
                        .WithMany("Products")
                        .HasForeignKey("OrderLineId");
                });

            modelBuilder.Entity("OrderMe_Angular.OMA.Models.User", b =>
                {
                    b.HasOne("OrderMe_Angular.OMA.Models.OrderLine", "OrderLine")
                        .WithMany("Users")
                        .HasForeignKey("OrderLineId");
                });
        }
    }
}
