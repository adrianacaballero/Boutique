namespace apiBoutiqueSecurity.Models
{
    using System.Data.Entity;

    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<apiBoutiqueSecurity.Models.Boutique> Boutiques { get; set; }
    }
}