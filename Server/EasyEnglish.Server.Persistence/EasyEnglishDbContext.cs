using EasyEnglish.Domain;
using Microsoft.EntityFrameworkCore;

namespace EasyEnglish.Server.Persistence
{
    public class EasyEnglishDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<UserInfo> UserInfos { get; set; }

        public DbSet<Vocabulary> Vocabularies { get; set; }

        public DbSet<Word> Words { get; set; }

        public DbSet<Test> Tests { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Answer> Answers { get; set; }

        public DbSet<TestResult> TestResults { get; set; }

        public EasyEnglishDbContext(DbContextOptions<EasyEnglishDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
