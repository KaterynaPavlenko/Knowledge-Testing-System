using System.Data.Entity;
using KnowledgeTestingSystem.DAL.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace KnowledgeTestingSystem.DAL.Context
{
    public class TestingSystemDbContext : IdentityDbContext<UserEntity>
    {
        static TestingSystemDbContext()
        {
            Database.SetInitializer(new TestingSystemContextInitializer());
        }

        public IDbSet<Answer> Answers { get; set; }
        public IDbSet<Question> Questions { get; set; }
        public IDbSet<QuestionsType> QuestionsTypes { get; set; }
        public IDbSet<Statistic> Statictics { get; set; }
        public IDbSet<Test> Tests { get; set; }
        public IDbSet<ThemeOfTest> ThemesOfTest { get; set; }

        public static TestingSystemDbContext Create()
        {
            return new TestingSystemDbContext();
        }
    }
}