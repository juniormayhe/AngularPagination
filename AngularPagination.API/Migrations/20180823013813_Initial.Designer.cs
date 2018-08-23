﻿// <auto-generated />
using AngularPagination.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AngularPagination.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20180823013813_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-preview1-35029");

            modelBuilder.Entity("AngularPagination.API.Models.Recipient", b =>
                {
                    b.Property<int>("RecipientId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<bool>("IsValid");

                    b.Property<string>("RecipientName");

                    b.Property<bool>("Unsubscribe");

                    b.HasKey("RecipientId");

                    b.ToTable("Recipients");
                });
#pragma warning restore 612, 618
        }
    }
}
