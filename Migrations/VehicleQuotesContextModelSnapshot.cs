﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using VehicleQuotes.Data;

#nullable disable

namespace VehicleQuotes.Migrations
{
    [DbContext(typeof(VehicleQuotesContext))]
    partial class VehicleQuotesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("VehicleQuotes.Models.BodyType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("ID")
                        .HasName("pk_bodytypes");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("ix_bodytypes_name");

                    b.ToTable("bodytypes", (string)null);
                });

            modelBuilder.Entity("VehicleQuotes.Models.Make", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("ID")
                        .HasName("pk_makes");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("ix_makes_name");

                    b.ToTable("makes", (string)null);
                });

            modelBuilder.Entity("VehicleQuotes.Models.Model", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int>("MakeID")
                        .HasColumnType("integer")
                        .HasColumnName("makeid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("ID")
                        .HasName("pk_models");

                    b.HasIndex("MakeID")
                        .HasDatabaseName("ix_models_makeid");

                    b.HasIndex("Name", "MakeID")
                        .IsUnique()
                        .HasDatabaseName("ix_models_name_makeid");

                    b.ToTable("models", (string)null);
                });

            modelBuilder.Entity("VehicleQuotes.Models.ModelStyle", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int>("BodyTypeID")
                        .HasColumnType("integer")
                        .HasColumnName("bodytypeid");

                    b.Property<int>("ModelID")
                        .HasColumnType("integer")
                        .HasColumnName("modelid");

                    b.Property<int>("SizeID")
                        .HasColumnType("integer")
                        .HasColumnName("sizeid");

                    b.HasKey("ID")
                        .HasName("pk_modelstyles");

                    b.HasIndex("BodyTypeID")
                        .HasDatabaseName("ix_modelstyles_bodytypeid");

                    b.HasIndex("SizeID")
                        .HasDatabaseName("ix_modelstyles_sizeid");

                    b.HasIndex("ModelID", "BodyTypeID", "SizeID")
                        .IsUnique()
                        .HasDatabaseName("ix_modelstyles_modelid_bodytypeid_sizeid");

                    b.ToTable("modelstyles", (string)null);
                });

            modelBuilder.Entity("VehicleQuotes.Models.ModelStyleYear", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int>("ModelStyleID")
                        .HasColumnType("integer")
                        .HasColumnName("modelstyleid");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("year");

                    b.HasKey("ID")
                        .HasName("pk_modelstyleyears");

                    b.HasIndex("ModelStyleID")
                        .HasDatabaseName("ix_modelstyleyears_modelstyleid");

                    b.HasIndex("Year", "ModelStyleID")
                        .IsUnique()
                        .HasDatabaseName("ix_modelstyleyears_year_modelstyleid");

                    b.ToTable("modelstyleyears", (string)null);
                });

            modelBuilder.Entity("VehicleQuotes.Models.Quote", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int>("BodyTypeID")
                        .HasColumnType("integer")
                        .HasColumnName("bodytypeid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("createdat");

                    b.Property<bool>("HasAllTires")
                        .HasColumnType("boolean")
                        .HasColumnName("hasalltires");

                    b.Property<bool>("HasAllWheels")
                        .HasColumnType("boolean")
                        .HasColumnName("hasallwheels");

                    b.Property<bool>("HasAlloyWheels")
                        .HasColumnType("boolean")
                        .HasColumnName("hasalloywheels");

                    b.Property<bool>("HasCompleteInterior")
                        .HasColumnType("boolean")
                        .HasColumnName("hascompleteinterior");

                    b.Property<bool>("HasEngine")
                        .HasColumnType("boolean")
                        .HasColumnName("hasengine");

                    b.Property<bool>("HasKey")
                        .HasColumnType("boolean")
                        .HasColumnName("haskey");

                    b.Property<bool>("HasTitle")
                        .HasColumnType("boolean")
                        .HasColumnName("hastitle");

                    b.Property<bool>("HasTransmission")
                        .HasColumnType("boolean")
                        .HasColumnName("hastransmission");

                    b.Property<bool>("ItMoves")
                        .HasColumnType("boolean")
                        .HasColumnName("itmoves");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("make");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("message");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("model");

                    b.Property<int?>("ModelStyleYearID")
                        .HasColumnType("integer")
                        .HasColumnName("modelstyleyearid");

                    b.Property<int>("OfferedQuote")
                        .HasColumnType("integer")
                        .HasColumnName("offeredquote");

                    b.Property<bool>("RequiresPickup")
                        .HasColumnType("boolean")
                        .HasColumnName("requirespickup");

                    b.Property<int>("SizeID")
                        .HasColumnType("integer")
                        .HasColumnName("sizeid");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("year");

                    b.HasKey("ID")
                        .HasName("pk_quotes");

                    b.HasIndex("BodyTypeID")
                        .HasDatabaseName("ix_quotes_bodytypeid");

                    b.HasIndex("ModelStyleYearID")
                        .HasDatabaseName("ix_quotes_modelstyleyearid");

                    b.HasIndex("SizeID")
                        .HasDatabaseName("ix_quotes_sizeid");

                    b.ToTable("quotes", (string)null);
                });

            modelBuilder.Entity("VehicleQuotes.Models.QuoteOverride", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int>("ModelStyleYearID")
                        .HasColumnType("integer")
                        .HasColumnName("modelstyleyearid");

                    b.Property<int>("Price")
                        .HasColumnType("integer")
                        .HasColumnName("price");

                    b.HasKey("ID")
                        .HasName("pk_quoteoverrides");

                    b.HasIndex("ModelStyleYearID")
                        .IsUnique()
                        .HasDatabaseName("ix_quoteoverrides_modelstyleyearid");

                    b.ToTable("quoteoverrides", (string)null);
                });

            modelBuilder.Entity("VehicleQuotes.Models.QuoteRule", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("FeatureType")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("featuretype");

                    b.Property<string>("FeatureValue")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("featurevalue");

                    b.Property<int>("PriceModifier")
                        .HasColumnType("integer")
                        .HasColumnName("pricemodifier");

                    b.HasKey("ID")
                        .HasName("pk_quoterules");

                    b.HasIndex("FeatureType", "FeatureValue")
                        .IsUnique()
                        .HasDatabaseName("ix_quoterules_featuretype_featurevalue");

                    b.ToTable("quoterules", (string)null);
                });

            modelBuilder.Entity("VehicleQuotes.Models.Size", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("ID")
                        .HasName("pk_sizes");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("ix_sizes_name");

                    b.ToTable("sizes", (string)null);

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Subcompact"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Compact"
                        },
                        new
                        {
                            ID = 3,
                            Name = "Mid Size"
                        },
                        new
                        {
                            ID = 4,
                            Name = "Full Size"
                        });
                });

            modelBuilder.Entity("VehicleQuotes.Models.Model", b =>
                {
                    b.HasOne("VehicleQuotes.Models.Make", "Make")
                        .WithMany()
                        .HasForeignKey("MakeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_models_makes_makeid");

                    b.Navigation("Make");
                });

            modelBuilder.Entity("VehicleQuotes.Models.ModelStyle", b =>
                {
                    b.HasOne("VehicleQuotes.Models.BodyType", "BodyType")
                        .WithMany()
                        .HasForeignKey("BodyTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_modelstyles_bodytypes_bodytypeid");

                    b.HasOne("VehicleQuotes.Models.Model", "Model")
                        .WithMany("ModelStyles")
                        .HasForeignKey("ModelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_modelstyles_models_modelid");

                    b.HasOne("VehicleQuotes.Models.Size", "Size")
                        .WithMany()
                        .HasForeignKey("SizeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_modelstyles_sizes_sizeid");

                    b.Navigation("BodyType");

                    b.Navigation("Model");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("VehicleQuotes.Models.ModelStyleYear", b =>
                {
                    b.HasOne("VehicleQuotes.Models.ModelStyle", "ModelStyle")
                        .WithMany("ModelStyleYears")
                        .HasForeignKey("ModelStyleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_modelstyleyears_modelstyles_modelstyleid");

                    b.Navigation("ModelStyle");
                });

            modelBuilder.Entity("VehicleQuotes.Models.Quote", b =>
                {
                    b.HasOne("VehicleQuotes.Models.BodyType", "BodyType")
                        .WithMany()
                        .HasForeignKey("BodyTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_quotes_bodytypes_bodytypeid");

                    b.HasOne("VehicleQuotes.Models.ModelStyleYear", "ModelStyleYear")
                        .WithMany()
                        .HasForeignKey("ModelStyleYearID")
                        .HasConstraintName("fk_quotes_modelstyleyears_modelstyleyearid");

                    b.HasOne("VehicleQuotes.Models.Size", "Size")
                        .WithMany()
                        .HasForeignKey("SizeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_quotes_sizes_sizeid");

                    b.Navigation("BodyType");

                    b.Navigation("ModelStyleYear");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("VehicleQuotes.Models.QuoteOverride", b =>
                {
                    b.HasOne("VehicleQuotes.Models.ModelStyleYear", "ModelStyleYear")
                        .WithMany()
                        .HasForeignKey("ModelStyleYearID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_quoteoverrides_modelstyleyears_modelstyleyearid");

                    b.Navigation("ModelStyleYear");
                });

            modelBuilder.Entity("VehicleQuotes.Models.Model", b =>
                {
                    b.Navigation("ModelStyles");
                });

            modelBuilder.Entity("VehicleQuotes.Models.ModelStyle", b =>
                {
                    b.Navigation("ModelStyleYears");
                });
#pragma warning restore 612, 618
        }
    }
}