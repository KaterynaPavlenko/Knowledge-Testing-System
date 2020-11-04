using System;
using System.Data.Entity;
using KnowledgeTestingSystem.DAL.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace KnowledgeTestingSystem.DAL.Context
{
    public class TestingSystemContextInitializer : DropCreateDatabaseAlways<TestingSystemDbContext>
    {
        protected override void Seed(TestingSystemDbContext context)
        {
            var userManager = new UserManager<UserEntity>(new UserStore<UserEntity>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            //create a new role Administrator
            var newRoleAdmin = new IdentityRole("Administrator");
            var roleCreateResult = roleManager.Create(newRoleAdmin);

            if (!roleCreateResult.Succeeded) throw new Exception(string.Join("; ", roleCreateResult.Errors));
            //create a new role Manager
            var newRoleManager = new IdentityRole("Manager");
            roleCreateResult = roleManager.Create(newRoleManager);

            if (!roleCreateResult.Succeeded) throw new Exception(string.Join("; ", roleCreateResult.Errors));
            //create a new role Client
            var newRoleClient = new IdentityRole("Client");
            roleCreateResult = roleManager.Create(newRoleClient);
            if (!roleCreateResult.Succeeded) throw new Exception(string.Join("; ", roleCreateResult.Errors));
            //create a new user as a admin
            var admin = new UserEntity {Email = "admin@mail.com", UserName = "admin@mail.com"};
            var password = "123456789";
            var resultAdmin = userManager.Create(admin, password);
            //create a new user as a manager
            var manager = new UserEntity {Email = "manager@mail.com", UserName = "manager@mail.com"};
            password = "123456789";
            var resultManager = userManager.Create(manager, password);
            //create a new user as a user
            var user = new UserEntity
            {
                Email = "user@mail.com",
                UserName = "user@mail.com",
                FirstName = "User",
                LastName = "User",
                PhoneNumber = "380998654312"
            };
            password = "123456789";
            var resultUser = userManager.Create(user, password);

            // if user creation was successful
            if (resultAdmin.Succeeded)
                // add a role for the user
                userManager.AddToRole(admin.Id, newRoleAdmin.Name);
            // if user creation was successful
            if (resultManager.Succeeded)
                // add a role for the user
                userManager.AddToRole(manager.Id, newRoleManager.Name);
            // if user creation was successful
            if (resultUser.Succeeded)
                // add a role for the user
                userManager.AddToRole(user.Id, newRoleClient.Name);
        }
    }
}