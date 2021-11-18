﻿using KinopoiskAPI.Dto;
using KinopoiskAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using KinopoiskAPI.Dto.Movie;

namespace KinopoiskAPI.Controllers
{
    [Route("api/[controller]")]
    public class CatalogController : Controller
    {
        private readonly IMovieService _movieService;

        public CatalogController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [AllowAnonymous]
        [HttpGet("get")]
        public async Task<IActionResult> Get(int id)
        {
            var movie = await _movieService.Get(id);
            if (movie == null)
                return BadRequest();
            return Ok(movie);
        }

        [AllowAnonymous]
        [HttpGet("get-page")]
        public async Task<IActionResult> GetPage(int page, int size = 8)
        {
            var movies = await _movieService.GetPage(new MoviePageDto()
            {
                PageNumber = page,
                PageSize = size,
            });
            return Ok(movies);
        }

        [AllowAnonymous]
        [HttpGet("get-by-title")]
        public async Task<IActionResult> GetMoviesByTitle(string title)
        {
            var movies = await _movieService.GetMoviesByTitle(title);
            return Ok(movies);
        }
    }
}