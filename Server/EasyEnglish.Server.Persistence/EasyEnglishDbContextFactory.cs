using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace EasyEnglish.Server.Persistence
{
    class EasyEnglishDbContextFactory : IDesignTimeDbContextFactory<EasyEnglishDbContext>
    {
        public EasyEnglishDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EasyEnglishDbContext>();
            optionsBuilder.UseMySql("server=localhost;UserId=root;Password=123456;database=easy_english;");

            return new EasyEnglishDbContext(optionsBuilder.Options);
        }
    }
}
