using DomainModel.Model;
using DomainModel.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class MoviesRepository : IMoviesRepository, IDisposable
    {
        private readonly IMyContext _context;

        public MoviesRepository()
            : this(new SampleContext()) { }

        public MoviesRepository(IMyContext context)
        {
            _context = context;
        }

        public IEnumerable<Movie> GetAll()
        {
            return _context.Movies.AsEnumerable();
        }

        public Movie Get(int id)
        {
            return _context.Movies.Find(id);
        }

        public void Add(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.FlushToDatabase();
        }

        public void Edit(Movie movie)
        {
            _context.Entry(movie).State = EntityState.Modified;
            _context.FlushToDatabase();
        }

        public void Delete(Movie movie)
        {
            _context.Movies.Remove(movie);
            _context.FlushToDatabase();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}