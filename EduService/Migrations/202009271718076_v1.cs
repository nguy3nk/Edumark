namespace EduService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        AccountId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        FullName = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        Image = c.String(),
                        GroupId = c.Int(),
                        PersonalId = c.Int(),
                        Birthday = c.DateTime(nullable: false),
                        Gender = c.Boolean(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AccountId)
                .ForeignKey("dbo.Group", t => t.GroupId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        AccountId = c.Int(),
                        CommentContent = c.String(),
                        PostId = c.Int(),
                        ReplyToCommentId = c.Int(),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Account", t => t.AccountId)
                .ForeignKey("dbo.BlogPost", t => t.PostId)
                .Index(t => t.AccountId)
                .Index(t => t.PostId);
            
            CreateTable(
                "dbo.BlogPost",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        BlogId = c.Int(),
                        PostTitle = c.String(),
                        PostImage = c.String(),
                        Resource = c.String(),
                        UploadDate = c.DateTime(nullable: false),
                        Author = c.String(),
                        BlogContent = c.String(),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.Blog", t => t.BlogId)
                .Index(t => t.BlogId);
            
            CreateTable(
                "dbo.Blog",
                c => new
                    {
                        BlogId = c.Int(nullable: false, identity: true),
                        BlogName = c.String(),
                    })
                .PrimaryKey(t => t.BlogId);
            
            CreateTable(
                "dbo.Group",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        GroupName = c.String(),
                        IsAdmin = c.Boolean(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.GroupId);
            
            CreateTable(
                "dbo.GroupRole",
                c => new
                    {
                        GroupId = c.Int(nullable: false),
                        BusinessId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GroupId, t.BusinessId, t.RoleId })
                .ForeignKey("dbo.Business", t => t.BusinessId, cascadeDelete: true)
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Group", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.BusinessId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Business",
                c => new
                    {
                        BusniessId = c.Int(nullable: false, identity: true),
                        Status = c.Boolean(nullable: false),
                        BusniessName = c.String(),
                    })
                .PrimaryKey(t => t.BusniessId);
            
            CreateTable(
                "dbo.PersonalRole",
                c => new
                    {
                        AccountId = c.Int(nullable: false),
                        BusinessId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AccountId, t.BusinessId, t.RoleId })
                .ForeignKey("dbo.Account", t => t.AccountId, cascadeDelete: true)
                .ForeignKey("dbo.Business", t => t.BusinessId, cascadeDelete: true)
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.AccountId)
                .Index(t => t.BusinessId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                        Description = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.Banner",
                c => new
                    {
                        BannerId = c.Int(nullable: false, identity: true),
                        BannerName = c.String(),
                        Image = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BannerId);
            
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        BookName = c.String(),
                    })
                .PrimaryKey(t => t.BookId);
            
            CreateTable(
                "dbo.Class",
                c => new
                    {
                        ClassId = c.Int(nullable: false, identity: true),
                        ClassName = c.String(),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        CourseId = c.Int(),
                        LecturerId = c.Int(),
                    })
                .PrimaryKey(t => t.ClassId)
                .ForeignKey("dbo.Course", t => t.CourseId)
                .ForeignKey("dbo.Lecturer", t => t.LecturerId)
                .Index(t => t.CourseId)
                .Index(t => t.LecturerId);
            
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        CourseName = c.String(),
                        Description = c.String(),
                        Image = c.String(),
                        Price = c.Single(nullable: false),
                        SalePrice = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.CourseId);
            
            CreateTable(
                "dbo.Feedback",
                c => new
                    {
                        FeedbackId = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(),
                        AccountId = c.Int(),
                        ReplyToCommentId = c.Int(),
                        evaluate = c.Int(nullable: false),
                        CommentContent = c.String(),
                    })
                .PrimaryKey(t => t.FeedbackId)
                .ForeignKey("dbo.Account", t => t.AccountId)
                .ForeignKey("dbo.Course", t => t.CourseId)
                .Index(t => t.CourseId)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.Program",
                c => new
                    {
                        ProgramId = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProgramId)
                .ForeignKey("dbo.Course", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Subject", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Exam",
                c => new
                    {
                        ExamId = c.Int(nullable: false, identity: true),
                        ExamTime = c.DateTime(nullable: false),
                        ProgramId = c.Int(),
                        ClassId = c.Int(),
                    })
                .PrimaryKey(t => t.ExamId)
                .ForeignKey("dbo.Class", t => t.ClassId)
                .ForeignKey("dbo.Program", t => t.ProgramId)
                .Index(t => t.ProgramId)
                .Index(t => t.ClassId);
            
            CreateTable(
                "dbo.Score",
                c => new
                    {
                        ExamId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        Value = c.Single(nullable: false),
                    })
                .PrimaryKey(t => new { t.ExamId, t.StudentId })
                .ForeignKey("dbo.Class", t => t.ExamId, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Exam", t => t.ExamId, cascadeDelete: true)
                .Index(t => t.ExamId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        AccountId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        ClassId = c.Int(),
                    })
                .PrimaryKey(t => t.AccountId)
                .ForeignKey("dbo.Account", t => t.AccountId)
                .ForeignKey("dbo.Class", t => t.ClassId)
                .Index(t => t.AccountId)
                .Index(t => t.ClassId);
            
            CreateTable(
                "dbo.Register",
                c => new
                    {
                        AccountID = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        IsExtraLab = c.Boolean(nullable: false),
                        PaidTime = c.DateTime(nullable: false),
                        Debt = c.Single(nullable: false),
                        Price = c.Single(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.AccountID, t.CourseId })
                .ForeignKey("dbo.Course", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.AccountID, cascadeDelete: true)
                .Index(t => t.AccountID)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Subject",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        Session = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.SubjectId);
            
            CreateTable(
                "dbo.Lecturer",
                c => new
                    {
                        AccountId = c.Int(nullable: false),
                        LecturerId = c.Int(nullable: false),
                        Faculty = c.String(),
                    })
                .PrimaryKey(t => t.AccountId)
                .ForeignKey("dbo.Account", t => t.AccountId)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.Extralab",
                c => new
                    {
                        CourseId = c.Int(nullable: false),
                        Session = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                        ClassId = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.CourseId)
                .ForeignKey("dbo.Course", t => t.CourseId)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Extralab", "CourseId", "dbo.Course");
            DropForeignKey("dbo.Class", "LecturerId", "dbo.Lecturer");
            DropForeignKey("dbo.Lecturer", "AccountId", "dbo.Account");
            DropForeignKey("dbo.Program", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.Score", "ExamId", "dbo.Exam");
            DropForeignKey("dbo.Score", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Register", "AccountID", "dbo.Student");
            DropForeignKey("dbo.Register", "CourseId", "dbo.Course");
            DropForeignKey("dbo.Student", "ClassId", "dbo.Class");
            DropForeignKey("dbo.Student", "AccountId", "dbo.Account");
            DropForeignKey("dbo.Score", "ExamId", "dbo.Class");
            DropForeignKey("dbo.Exam", "ProgramId", "dbo.Program");
            DropForeignKey("dbo.Exam", "ClassId", "dbo.Class");
            DropForeignKey("dbo.Program", "CourseId", "dbo.Course");
            DropForeignKey("dbo.Feedback", "CourseId", "dbo.Course");
            DropForeignKey("dbo.Feedback", "AccountId", "dbo.Account");
            DropForeignKey("dbo.Class", "CourseId", "dbo.Course");
            DropForeignKey("dbo.Account", "GroupId", "dbo.Group");
            DropForeignKey("dbo.GroupRole", "GroupId", "dbo.Group");
            DropForeignKey("dbo.PersonalRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.GroupRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.PersonalRole", "BusinessId", "dbo.Business");
            DropForeignKey("dbo.PersonalRole", "AccountId", "dbo.Account");
            DropForeignKey("dbo.GroupRole", "BusinessId", "dbo.Business");
            DropForeignKey("dbo.Comment", "PostId", "dbo.BlogPost");
            DropForeignKey("dbo.BlogPost", "BlogId", "dbo.Blog");
            DropForeignKey("dbo.Comment", "AccountId", "dbo.Account");
            DropIndex("dbo.Extralab", new[] { "CourseId" });
            DropIndex("dbo.Lecturer", new[] { "AccountId" });
            DropIndex("dbo.Register", new[] { "CourseId" });
            DropIndex("dbo.Register", new[] { "AccountID" });
            DropIndex("dbo.Student", new[] { "ClassId" });
            DropIndex("dbo.Student", new[] { "AccountId" });
            DropIndex("dbo.Score", new[] { "StudentId" });
            DropIndex("dbo.Score", new[] { "ExamId" });
            DropIndex("dbo.Exam", new[] { "ClassId" });
            DropIndex("dbo.Exam", new[] { "ProgramId" });
            DropIndex("dbo.Program", new[] { "SubjectId" });
            DropIndex("dbo.Program", new[] { "CourseId" });
            DropIndex("dbo.Feedback", new[] { "AccountId" });
            DropIndex("dbo.Feedback", new[] { "CourseId" });
            DropIndex("dbo.Class", new[] { "LecturerId" });
            DropIndex("dbo.Class", new[] { "CourseId" });
            DropIndex("dbo.PersonalRole", new[] { "RoleId" });
            DropIndex("dbo.PersonalRole", new[] { "BusinessId" });
            DropIndex("dbo.PersonalRole", new[] { "AccountId" });
            DropIndex("dbo.GroupRole", new[] { "RoleId" });
            DropIndex("dbo.GroupRole", new[] { "BusinessId" });
            DropIndex("dbo.GroupRole", new[] { "GroupId" });
            DropIndex("dbo.BlogPost", new[] { "BlogId" });
            DropIndex("dbo.Comment", new[] { "PostId" });
            DropIndex("dbo.Comment", new[] { "AccountId" });
            DropIndex("dbo.Account", new[] { "GroupId" });
            DropTable("dbo.Extralab");
            DropTable("dbo.Lecturer");
            DropTable("dbo.Subject");
            DropTable("dbo.Register");
            DropTable("dbo.Student");
            DropTable("dbo.Score");
            DropTable("dbo.Exam");
            DropTable("dbo.Program");
            DropTable("dbo.Feedback");
            DropTable("dbo.Course");
            DropTable("dbo.Class");
            DropTable("dbo.Book");
            DropTable("dbo.Banner");
            DropTable("dbo.Role");
            DropTable("dbo.PersonalRole");
            DropTable("dbo.Business");
            DropTable("dbo.GroupRole");
            DropTable("dbo.Group");
            DropTable("dbo.Blog");
            DropTable("dbo.BlogPost");
            DropTable("dbo.Comment");
            DropTable("dbo.Account");
        }
    }
}
