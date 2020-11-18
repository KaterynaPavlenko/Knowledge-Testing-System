using System.Security.Claims;
using System.Threading.Tasks;
using KnowledgeTestingSystem.DAL.Entity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace KnowledgeTestingSystem.BLL.Services
{
    public class TestingSystemSignInManager : SignInManager<UserEntity, string>
    {
        public TestingSystemSignInManager(TestingSystemUserManager userManager,
            IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(UserEntity user)
        {
            return user.GenerateUserIdentityAsync((TestingSystemUserManager) UserManager);
        }

        public static TestingSystemSignInManager Create(IdentityFactoryOptions<TestingSystemSignInManager> options,
            IOwinContext context)
        {
            return new TestingSystemSignInManager(context.GetUserManager<TestingSystemUserManager>(),
                context.Authentication);
        }
    }
}