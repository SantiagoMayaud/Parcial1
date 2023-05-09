using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Parcial1SM.Models;

namespace Parcial1SM.Data
{
    public class ModelKitContext : DbContext
    {
        public ModelKitContext (DbContextOptions<ModelKitContext> options)
            : base(options)
        {
        }

        public DbSet<Parcial1SM.Models.ModelKit> ModelKit { get; set; } = default!;
        public DbSet<Parcial1SM.Models.ModelMaker> ModelMaker { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ModelMaker>()
            .HasMany(p => p.ModelKits)
            .WithOne(p => p.ModelMaker)
            .HasForeignKey (p=> p.ModelMakerId);
        }
    }
}
