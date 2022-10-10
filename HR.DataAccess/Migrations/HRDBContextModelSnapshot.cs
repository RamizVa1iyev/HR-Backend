using System;
using HR.DataAccess.Concrete.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HR.DataAccess.Migrations
{
    [DbContext(typeof(HRDBContext))]
    partial class HRDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);


            modelBuilder.Entity("HR.Entities.Concrete.State", b =>
            modelBuilder.Entity("HR.Entities.Concrete.CalendarDay", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)")
                    .HasColumnName("Name");

                b.Property<int>("ParentId")
                    .HasColumnType("int")
                    .HasColumnName("ParentId");

                b.HasKey("Id");

                b.ToTable("States", (string)null);
            }));


            modelBuilder.Entity("HR.Entities.Concrete.UserKey", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                b.Property<DateTime>("CreateDate")
                    .HasColumnType("datetime2")
                    .HasColumnName("CreateDate");

                b.Property<bool>("IsUsed")
                    .HasColumnType("bit")
                    .HasColumnName("IsUsed");

                b.Property<string>("SecretKey")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)")
                    .HasColumnName("SecretKey");

                b.Property<int>("UserId")
                    .HasColumnType("int")
                    .HasColumnName("UserId");

                b.HasKey("Id");

                b.ToTable("UserKeys", (string)null);

                b.Property<DateTime>("Date")
                    .HasColumnType("datetime2")
                    .HasColumnName("Date");

                b.Property<int>("DayType")
                    .HasColumnType("int")
                    .HasColumnName("DayType");

                b.HasKey("Id");

                b.ToTable("CalendarDays", (string)null);

            });
        }
    }
}