using Microsoft.AspNetCore.Identity;

namespace BulkyWeb_1._0.Data
{
    public class ApplicationUser:IdentityUser
    {
        public string Name  { get; set; }
        public string ? ProfilePicture { get; set; }


    }
}
