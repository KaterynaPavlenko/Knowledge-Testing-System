using System;
using System.Collections.Generic;
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

            var tests = new List<Test>
            {
                new Test
                {
                    Id = 1,
                    Name = "First test",
                    ThemeOfTestId = 1,
                    TimeMinutes = 1,
                    CoverImage = "~/Content/Image/compass.jpg"
                },
                new Test
                {
                    Id = 2,
                    Name = "Second test",
                    ThemeOfTestId = 2,
                    TimeMinutes = 13,
                    CoverImage = "~/Content/Image/compass.jpg"
                },
                new Test
                {
                    Id = 3,
                    Name = "Third test",
                    ThemeOfTestId = 1,
                    TimeMinutes = 17,
                    CoverImage = "~/Content/Image/geometry.jpg"
                },
                new Test
                {
                    Id = 4,
                    Name = "Fourth test",
                    ThemeOfTestId = 2,
                    TimeMinutes = 120,
                    CoverImage = "~/Content/Image/geometry.jpg"
                }
            };
            tests.ForEach(std => context.Tests.Add(std));
            var themesOfTests = new List<ThemeOfTest>
            {
                new ThemeOfTest
                {
                    Id = 1,
                    Theme = "Math"
                },
                new ThemeOfTest
                {
                    Id = 2,
                    Theme = "Languages"
                },
                new ThemeOfTest
                {
                    Id = 3,
                    Theme = "Geometry"
                },
                new ThemeOfTest
                {
                    Id = 4,
                    Theme = "History"
                }
            };
            themesOfTests.ForEach(std => context.ThemesOfTest.Add(std));
            context.SaveChanges();
            var questionList = new List<Question>
            {
                new Question
                {
                    Id = 1,
                    Text = "Что характеризует координатную ось?",
                    TestId = 1
                },
                new Question
                {
                    Id = 2,
                    Text = "Как расположено на координатной оси бОльшее из двух чисел?",
                    TestId = 1
                },
                new Question
                {
                    Id = 3,
                    TestId = 1
                },
                new Question
                {
                    Id = 4,
                    TestId = 1
                }
            };
            questionList.ForEach(std => context.Questions.Add(std));
            context.SaveChanges();

            var answers = new List<Answer>
            {
                new Answer
                {
                    Id = 1,
                    Text = "Начало координат",
                    QuestionId = 1,
                    IsCorrect = true
                },
                new Answer
                {
                    Id = 2,
                    Text = "Начало координат, единица масштаба и направление",
                    IsCorrect = true,
                    QuestionId = 1
                },
                new Answer
                {
                    Id = 3,
                    Text = "Направление",
                    IsCorrect = false,
                    QuestionId = 1
                },
                new Answer
                {
                    Id = 4,
                    Text = "Единица масштаба",
                    IsCorrect = false,
                    QuestionId = 1
                }
            };
            answers.ForEach(std => context.Answers.Add(std));
            context.SaveChanges();
            var questionType=new List<QuestionType>
            {
                new QuestionType
                {
                    Id = 1
                },
                new QuestionType
                {
                    Id = 2
                },new QuestionType
                {
                    Id = 3
                }
            };
          
        }
    }
}