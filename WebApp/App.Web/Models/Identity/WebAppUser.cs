using App.Web.Models.Domain;
using Microsoft.AspNetCore.Identity;
namespace App.Web.Models.Identity
{
    public class WebAppUser:IdentityUser
    {
        public string FirstName { get; set; }  
        public string LastName { get; set; }
        public string Address { get; set; }
        public virtual ShoppingCart UserCart { get; set; }
    }
}
