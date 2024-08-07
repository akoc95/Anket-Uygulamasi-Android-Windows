using Microsoft.EntityFrameworkCore;
using SurveyApp.Models;


namespace SurveyApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
            // Ctor işlemleri gerek olursa.
        }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<SurveyResponse> SurveyResponses { get; set; }
        public DbSet<SurveyAnswer> SurveyAnswers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var dbPath = Path.Combine(FileSystem.AppDataDirectory, "surveyApp.db");

            //optionsBuilder.UseSqlite($"Filename = {dbPath}");

            optionsBuilder.UseSqlite("Data Source = surveyApp.db");
        }

    }
}
