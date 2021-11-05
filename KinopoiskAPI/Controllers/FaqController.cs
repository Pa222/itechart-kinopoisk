﻿using System.Threading.Tasks;
using KinopoiskAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KinopoiskAPI.Controllers
{
    [Route("/api/[controller]")]
    public class FaqController : Controller
    {
        private readonly IFaqService _faqService;

        public FaqController(IFaqService faqService)
        {
            _faqService = faqService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var faqs = await _faqService.GetAll();
            return Ok(faqs);
        }
    }
}