﻿using KinopoiskAPI.Dto;
using KinopoiskAPI.Services.Interfaces;
using KinopoiskAPI.Utils.CloudinaryApi;
using KinopoiskAPI.Utils.Hasher;
using KinopoiskAPI.Utils.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System;
using System.Threading.Tasks;
using KinopoiskAPI.Dto.User;

namespace KinopoiskAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICloudinaryApi _cloudinaryApi;

        public UserController(IUserService userService, ICloudinaryApi cloudinaryApi)
        {
            _userService = userService;
            _cloudinaryApi = cloudinaryApi;
        }

        [Authorize]
        [HttpGet("get-user")]
        public async Task<IActionResult> GetUser()
        {
            var token = Request.Headers[HeaderNames.Authorization].ToString();
            var email = JwtDecoder.GetEmail(token[7..]);
            var user = await _userService.GetUser(email);

            if (user == null)
                return Unauthorized();

            return Ok(_userService.GetUserInfo(user));
        }

        [Authorize]
        [HttpPost("upload-avatar")]
        public async Task<IActionResult> UploadAvatar()
        {
            var token = Request.Headers[HeaderNames.Authorization].ToString();
            var email = JwtDecoder.GetEmail(token[7..]);
            var user = await _userService.GetUser(email);

            if (await _userService.GetUser(email) == null)
                return Unauthorized();

            try
            {
                var file = Request.Form.Files[0];
                if (file.Length <= 0) return BadRequest();

                var fileUrl = await _cloudinaryApi.UploadFile(file, email);

                if (fileUrl == null)
                    return BadRequest();

                user.Avatar = fileUrl;

                if (await _userService.UpdateUser(user))
                    return Ok(_userService.GetUserInfo(user));
                return BadRequest();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [AllowAnonymous]
        [HttpPost("auth")]
        public async Task<IActionResult> Auth([FromBody] UserLoginDto info)
        {
            if (info == null)
                return BadRequest();

            var user = await _userService.GetUser(info.Email);

            if (user == null || !Hasher.CheckPassword(info.Password, user.Password, user.Salt))
                return Unauthorized();

            return Ok(_userService.GetToken(user));
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto info)
        {
            if (info == null)
                return BadRequest();

            var user = await _userService.GetUser(info.Email);
            if (user != null)
                return BadRequest();

            if (await _userService.AddUser(info))
                return Ok();
            return BadRequest();
        }
    }
}