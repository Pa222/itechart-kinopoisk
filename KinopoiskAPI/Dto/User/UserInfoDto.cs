﻿using KinopoiskAPI.Dto.CreditCard;
using System.Collections.Generic;

namespace KinopoiskAPI.Dto.User
{
    public class UserInfoDto
    {
        public string Role { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string Avatar { get; set; }
        public List<CreditCardInfoDto> CreditCards { get; set; }
    }
}