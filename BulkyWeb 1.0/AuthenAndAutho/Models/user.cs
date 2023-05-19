using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthenAndAutho.Models
{
    public class user
    {
        public int UserId { get; set; }
        public string UserName { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string email { get; set; }

        public string password { get; set; }

        public bool IsActive { get; set; }

        public Guid activationCode { get; set; }

        public virtual ICollection<role> Roles { get; set; }

    }
}
