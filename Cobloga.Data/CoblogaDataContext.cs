using Cobloga.Data.DataModel;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Cobloga.Data
{
    public class CoblogaDataContext : DbContext
    {
        public CoblogaDataContext() : base("CoblogaDataContext")
        {
        }

        public DbSet<CbaPost> CbaPost { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
