using Microsoft.AspNetCore.Identity;

namespace SonMVCApp.Models
{
    public class AppUser:IdentityUser
    {
        public string Name {  get; set; }
    }
}
