using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using _51EntityCoreMany;

namespace _51EntityCoreMany.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20170501035504_Mymanytomany")]
    partial class Mymanytomany
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("_51EntityCoreMany.ModelImage", b =>
                {
                    b.Property<int>("ModelImageId")
                        .ValueGeneratedOnAdd();

                    b.HasKey("ModelImageId");

                    b.ToTable("ModelImages");
                });

            modelBuilder.Entity("_51EntityCoreMany.ModelImageTag", b =>
                {
                    b.Property<int>("ModelImageId");

                    b.Property<int>("ModelTagId");

                    b.HasKey("ModelImageId", "ModelTagId");

                    b.HasIndex("ModelTagId");

                    b.ToTable("ModelImageTag");
                });

            modelBuilder.Entity("_51EntityCoreMany.ModelTag", b =>
                {
                    b.Property<int>("ModelTagId")
                        .ValueGeneratedOnAdd();

                    b.HasKey("ModelTagId");

                    b.ToTable("ModelTags");
                });

            modelBuilder.Entity("_51EntityCoreMany.ModelImageTag", b =>
                {
                    b.HasOne("_51EntityCoreMany.ModelImage", "ModelImage")
                        .WithMany("Tags")
                        .HasForeignKey("ModelImageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("_51EntityCoreMany.ModelTag", "ModelTag")
                        .WithMany("Images")
                        .HasForeignKey("ModelTagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
