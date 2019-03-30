using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CameraBazar.Models.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CameraBazzar.Models.EntityModels
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Cameras = new HashSet<Camera>();
        }


        ////public int Id { get; set; }
        //[StringLength(20, ErrorMessage = "Username must be between 4 and 20 symbols long.", MinimumLength = 4)]
        //[RegularExpression("[a-zA-Z]+", ErrorMessage = "Username must be contain only letters.")]
        //public string UserName { get; set; }
        //[RegularExpression("^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$", ErrorMessage ="Email can be valid.")]
        //public string Email { get; set; }
        //[StringLength(int.MaxValue,ErrorMessage = "The Password must be at least 3 symbols long.", MinimumLength = 3)]
        //[RegularExpression("[a-z0-9]+", ErrorMessage = "Password must be contains only lowercase letters and digits.")]
        //public string Password { get; set; }
        [RegularExpression("^[+][0-9]\\d{10,12}", ErrorMessage = "Phone must be start with “+“ and between 10 and 12 symbols long.")]
        public string Phone { get; set; }        

        public virtual ICollection<Camera> Cameras { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}