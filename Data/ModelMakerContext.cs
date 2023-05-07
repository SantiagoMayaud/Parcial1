using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Parcial1SM.Models;

namespace Parcial1SM.data
{
    public class ModelMakerContext : DbContext
    {
        public ModelMakerContext (DbContextOptions<ModelMakerContext> options)
            : base(options)
        {
        }

        public DbSet<Parcial1SM.Models.ModelMaker> ModelMaker { get; set; } = default!;
        public DbSet<Parcial1SM.Models.ModelKit> ModelKit { get; set; } = default!;
        
    }
}
