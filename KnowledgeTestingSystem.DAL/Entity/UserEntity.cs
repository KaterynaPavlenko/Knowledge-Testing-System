using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace KnowledgeTestingSystem.DAL.Entity
{
    public class UserEntity : IdentityUser
    {
        /// <summary>
        ///     The first name of the user
        /// </summary>
        [StringLength(30, MinimumLength = 3)]
        public string FirstName { get; set; }

        /// <summary>
        ///     The last name of the user
        /// </summary>

        [StringLength(30, MinimumLength = 3)]
        public string LastName { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<UserEntity> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}