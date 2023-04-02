namespace Project_Sem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anchs : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "BirthDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AspNetUsers", "isResigned", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "isResigned", c => c.Boolean());
            AlterColumn("dbo.AspNetUsers", "BirthDate", c => c.DateTime());
        }
    }
}
