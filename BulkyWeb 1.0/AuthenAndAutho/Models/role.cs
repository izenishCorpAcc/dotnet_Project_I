﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthenAndAutho.Models
{
    public class role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public virtual ICollection<user> Users { get; set; }

    }
}