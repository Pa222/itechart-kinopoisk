﻿using Data_Access_Layer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data_Access_Layer.Entity;

namespace Data_Access_Layer.Repositories
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(AppDbContext db) : base(db)
        {
        }

        public async Task<List<Comment>> GetAllByMovie(int id)
        {
            return await Db.Comments.AsNoTracking().Where(c => c.MovieId == id).ToListAsync();
        }
    }
}