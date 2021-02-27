using Amizade.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;


namespace Amizade.Infrastructure.Data.Context
{
    public class AmizadeContext : DbContext
    {
        public AmizadeContext (DbContextOptions<AmizadeContext> options)
            : base(options)
        {
        }

        public DbSet<AmigoEntity> AmigoEntity { get; set; }
    }
}
