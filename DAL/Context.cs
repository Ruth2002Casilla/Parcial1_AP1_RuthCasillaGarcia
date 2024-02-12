using Microsoft.EntityFrameworkCore;
using Parcial1_AP1_RuthCasillaGarcia.Models;

namespace Parcial1_AP1_RuthCasillaGarcia.DAL
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context>options) : base(options) { }
        public DbSet<Metas> Metas { get; set; }
    }
}
