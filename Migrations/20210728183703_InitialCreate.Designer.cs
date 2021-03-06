// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using csi_media_test.Data;

namespace csi_media_test.Migrations
{
    [DbContext(typeof(csiDBContext))]
    [Migration("20210728183703_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.8");

            modelBuilder.Entity("csi_media_test.Models.DBO_SortedNumModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Number")
                        .HasColumnType("TEXT");

                    b.Property<string>("SortType")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("SortedNumModel");
                });
#pragma warning restore 612, 618
        }
    }
}
