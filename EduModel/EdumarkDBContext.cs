using EduModel.Models;

namespace EduModel
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class EdumarkDBContext : DbContext
    {
        public EdumarkDBContext() : base("name=EdumarkDBContext")
        {
            
        }

        public virtual DbSet<Account> Accounts { get; set; }

        public virtual DbSet<Banner> Banners { get; set; }

        public virtual DbSet<Blog> Blogs { get; set; }

        public virtual DbSet<BlogPost> BlogPosts { get; set; }

        public virtual DbSet<Book> Books { get; set; }

        public virtual DbSet<Business> Businesses { get; set; }

        public virtual DbSet<Class> Classes { get; set; }

        public virtual DbSet<Comment> Comments { get; set; }

        public virtual DbSet<Course> Courses { get; set; }

        public virtual DbSet<Exam> Exams { get; set; }

        public virtual DbSet<Extralab> Extralabs { get; set; }

        public virtual DbSet<Feedback> Feedbacks { get; set; }

        public virtual DbSet<Group> Groups { get; set; }

        public virtual DbSet<GroupRole> GroupRoles { get; set; }

        public virtual DbSet<Lecturer> Lecturers { get; set; }

        public virtual DbSet<PersonalRole> PersonalRoles { get; set; }

        public virtual DbSet<Program> Programs { get; set; }

        public virtual DbSet<Register> Registers { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<Score> Scores { get; set; }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<Subject> Subjects { get; set; }
    }

}