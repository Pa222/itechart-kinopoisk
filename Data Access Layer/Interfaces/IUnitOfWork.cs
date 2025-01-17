﻿using Data_Access_Layer.Entity;
using Data_Access_Layer.Repositories.Interfaces;

namespace Data_Access_Layer.Interfaces
{
    public interface IUnitOfWork
    {
        IMovieRepository Movies { get; }
        IRepository<Genre> Genres { get; }
        IRepository<Faq> Faqs { get; }
        ICreditCardRepository CreditCards { get; }
        IUserRepository Users { get; }
        ICommentRepository Comments { get; }

        IRatingRepository Ratings { get; }
    }
}