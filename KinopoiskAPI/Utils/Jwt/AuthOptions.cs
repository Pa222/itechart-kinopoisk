﻿using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace KinopoiskAPI.Jwt
{
    public class AuthOptions
    {
        public const string Iss = "KinopoiskAPI";
        public const string Aud = "KinopoiskAPIClient";
        public const string Key = "7yQQjEQlxuivhMl2WvZJbewTwJSCAHp5";
        public const int LifeTime = 20;

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
        }
    }
}