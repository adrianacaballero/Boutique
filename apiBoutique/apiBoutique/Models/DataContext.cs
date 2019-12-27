
namespace apiBoutique.Models
{
    using System.Data.Entity;

    public class DataContext: DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<apiBoutique.Models.Boutique> Boutiques { get; set; }
    }
}