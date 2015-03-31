using DomainModel.Model;
using System.Collections.Generic;

namespace DomainModel.Repositories
{
    public interface IMoviesRepository
    {
        IEnumerable<Movie> GetAll();
        Movie Get(int id);
        void Add(Movie movie);
        void Edit(Movie movie);
        void Delete(Movie movie);
    }
}