// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using VehicleQuotes.Data;

#nullable disable

namespace VehicleQuotes.Migrations
{
    [DbContext(typeof(VehicleQuotesContext))]
    [Migration("20221203115702_AddVehicleModelTables")]
    partial class AddVehicleModelTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.HasIndex("ModelID")
                        .HasDatabaseName("ix_modelstyles_modelid");

                    b.HasIndex("SizeID")
                        .HasDatabaseName("ix_modelstyles_sizeid");

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

                    b.ToTable("modelstyleyears", (string)null);
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
