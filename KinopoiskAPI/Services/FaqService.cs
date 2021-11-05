﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Model;
using KinopoiskAPI.Services.Interfaces;

namespace KinopoiskAPI.Services
{
    public class FaqService : IFaqService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FaqService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ICollection<Faq>> GetAll()
        {
            return await _unitOfWork.Faqs.GetAll();
        }
    }
}