﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Data.Entities
{
    public class User : IdentityUser
    {
        public Profile Profile { get; set; }
    }
}
