namespace Project_Sem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnswerResult",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        CompetitionId = c.Int(),
                        Answer = c.String(),
                        Mark = c.Double(),
                        Date = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.Competitions", t => t.CompetitionId)
                .Index(t => t.UserId)
                .Index(t => t.CompetitionId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Name = c.String(),
                        Image = c.String(),
                        BirthDate = c.DateTime(nullable: false, storeType: "date"),
                        isResigned = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Registration",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(maxLength: 50),
                        JoinDate = c.DateTime(storeType: "date"),
                        RollNo = c.String(maxLength: 128),
                        ClassId = c.Int(),
                        Specification = c.String(maxLength: 50),
                        Section = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.RollNo)
                .Index(t => t.RollNo);
            
            CreateTable(
                "dbo.UserCompetition",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        CompetitionId = c.Int(nullable: false),
                        isStatus = c.Boolean(),
                    })
                .PrimaryKey(t => new { t.UserId, t.CompetitionId })
                .ForeignKey("dbo.Competitions", t => t.CompetitionId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.CompetitionId);
            
            CreateTable(
                "dbo.Competitions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 100),
                        Description = c.String(maxLength: 250),
                        StartDate = c.DateTime(nullable: false, storeType: "date"),
                        EndDate = c.DateTime(nullable: false, storeType: "date"),
                        Question = c.String(),
                        RightAnswer = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FAQ",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Question = c.String(maxLength: 150),
                        Answer = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Register",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Resigned = c.Boolean(),
                        UserId = c.Int(),
                        Name = c.String(maxLength: 50),
                        BirthDate = c.DateTime(storeType: "date"),
                        Phone = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        CreateDate = c.DateTime(storeType: "date"),
                        Image = c.String(maxLength: 200, unicode: false),
                        isAccepted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Supports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Phone = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Position = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserCompetition", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserCompetition", "CompetitionId", "dbo.Competitions");
            DropForeignKey("dbo.AnswerResult", "CompetitionId", "dbo.Competitions");
            DropForeignKey("dbo.Registration", "RollNo", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AnswerResult", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserCompetition", new[] { "CompetitionId" });
            DropIndex("dbo.UserCompetition", new[] { "UserId" });
            DropIndex("dbo.Registration", new[] { "RollNo" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AnswerResult", new[] { "CompetitionId" });
            DropIndex("dbo.AnswerResult", new[] { "UserId" });
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.Supports");
            DropTable("dbo.Register");
            DropTable("dbo.FAQ");
            DropTable("dbo.Competitions");
            DropTable("dbo.UserCompetition");
            DropTable("dbo.Registration");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AnswerResult");
        }
    }
}
