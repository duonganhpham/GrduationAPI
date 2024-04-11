﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationProjectAPI.Business.Models
{
    public class UserRequestModel
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string AvatarUrl { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
    }
}
