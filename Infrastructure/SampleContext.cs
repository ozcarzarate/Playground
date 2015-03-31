using DomainModel.Model;
using System;
using System.Data.Entity;

namespace Infrastructure
{
    public class SampleContext : DbContext, IMyContext, IDisposable
    {

        public DbSet<Client> Clients { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public void FlushToDatabase()
        {
            SaveChanges();
        }
    }
}
