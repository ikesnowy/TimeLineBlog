﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TimeLineBlog.Models;

namespace TimeLineBlog.Migrations
{
    [DbContext(typeof(TimeLineBlogContext))]
    [Migration("20190306062856_PlainText")]
    partial class PlainText
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TimeLineBlog.Models.Article", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("HTMLContent");

                    b.Property<DateTime>("LastModifyTime");

                    b.Property<string>("MarkdownContent");

                    b.Property<string>("PlainContent");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.HasKey("ID");

                    b.ToTable("Article");
                });
#pragma warning restore 612, 618
        }
    }
}
