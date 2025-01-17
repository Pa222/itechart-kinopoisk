﻿using Data_Access_Layer.Entity;
using Data_Access_Layer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repositories
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        public MovieRepository(AppDbContext db) : base(db)
        {
        }

        public async Task<List<Movie>> GetAllAsync()
        {
            return await Db.Movies
                .Include(s => s.GenreMovies)
                .ThenInclude(s => s.Genre)
                .ToListAsync();
        }

        public async Task<List<Movie>> GetPageAsync(int pageNumber, int pageSize)
        {
            var delta = pageNumber == 1 ? 0 : pageNumber - 1;
            return await Db.Movies
                .Include(s => s.GenreMovies)
                .ThenInclude(s => s.Genre)
                .Skip(delta * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public decimal GetAmountOfMovies()
        {
            return Db.Movies.Count();
        }

        public async Task<List<Movie>> GetMoviesByTitle(string title)
        {
            return await Db.Movies
                .Include(s => s.GenreMovies)
                .ThenInclude(s => s.Genre)
                .Where(m => m.Title.Contains(title))
                .ToListAsync();
        }

        public async Task<Movie> GetAsync(int id)
        {
            return await Db.Movies
                .Include(s => s.GenreMovies)
                .ThenInclude(s => s.Genre)
                .Include(s => s.Comments)
                .Include(m => m.Ratings)
                .FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}