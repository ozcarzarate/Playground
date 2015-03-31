using DomainModel.Model;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Infrastructure
{
    public interface IMyContext : IDisposable
    {
        DbSet<Client> Clients { get; set; }
        DbSet<Movie> Movies { get; set; }
        void FlushToDatabase();
        DbEntityEntry Entry(object entity);
    }
}
