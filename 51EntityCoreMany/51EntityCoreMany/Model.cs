using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _51EntityCoreMany
{
    public class MyContext : DbContext
    {
        public DbSet<ModelImage> ModelImages { get; set; }
        public DbSet<ModelTag> ModelTags { get; set; }         

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=ModelImageDatabase.db");
        } 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ModelImageTag>()
                .HasKey(x => new { x.ModelImageId, x.ModelTagId });
            modelBuilder.Entity<ModelImageTag>()
                .HasOne(x => x.ModelImage)
                .WithMany(x => x.Tags)
                .HasForeignKey(x => x.ModelImageId);
            modelBuilder.Entity<ModelImageTag>()
                .HasOne(x => x.ModelTag)
                .WithMany(x => x.Images)
                .HasForeignKey(x => x.ModelTagId);
        }
    }
    public class ModelImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ModelImageId { get; set; }

        public List<ModelImageTag> Tags { get; set; }
    }

    public class ModelTag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ModelTagId { get; set; }

        public List<ModelImageTag> Images { get; set; }
    }

    public class ModelImageTag
    {
        public int ModelImageId { get; set; }
        public ModelImage ModelImage { get; set; }

        public int ModelTagId { get; set; }
        public ModelTag ModelTag { get; set; }
    }  
}
