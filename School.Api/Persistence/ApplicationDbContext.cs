//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;
//using School.Api.Entities;
//using System.Reflection;

//namespace School.Api.Persistence
//{
//    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser, ApplicationRole,string>(options)
//    {
//        public DbSet<Answer> Answers { get; set; }
//        public DbSet<Class> Classes { get; set; }
//        public DbSet<ClassLecture> Lectures { get; set; }
//        public DbSet<Exam> Exams { get; set; }
//        public DbSet<ExamStudentScore> ExamScores  { get; set; }
//        public DbSet<ExamType> ExamTypes { get; set; }
//        public DbSet<Grade> Grades { get; set; }
//        public DbSet<Lesson> Lessons { get; set; }
//        public DbSet<LessonResources> LessonResources { get; set; }
//        public DbSet<Level> Levels { get; set; }
//        public DbSet<Question> Questions { get; set; }
//        public DbSet<Region> Regions { get; set; }
///*        public DbSet<Student> Students { get; set; }
//*/        public DbSet<Subject> Subjects { get; set; }
//        public DbSet<Subscription> Subscriptions { get; set; }
//        public DbSet<SubscriptionTier> SubscriptionTiers { get; set; }



//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
//            base.OnModelCreating(modelBuilder);




//            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes()
//                .SelectMany(e => e.GetForeignKeys()))
//            {
//                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
//            }
//        }
//    }
//}





using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using School.Api.Entities;
using System.Reflection;

namespace School.Api.Persistence
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser, ApplicationRole, string>(options)
    {
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<ClassLecture> Lectures { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamStudentScore> ExamScores { get; set; }
        public DbSet<ExamType> ExamTypes { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<LessonResources> LessonResources { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Region> Regions { get; set; }
        /*        public DbSet<Student> Students { get; set; }
        */
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<SubscriptionTier> SubscriptionTiers { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);

            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Level)
                .WithMany(l => l.Grades)
                .HasForeignKey(g => g.LevelId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}