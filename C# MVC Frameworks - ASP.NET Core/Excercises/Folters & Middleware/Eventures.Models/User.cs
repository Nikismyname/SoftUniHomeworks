namespace Eventures.Models
{
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
        public string  FirstName { get; set; }

        public string LastName { get; set; }

        public string  UCN { get; set; }
    }
}
