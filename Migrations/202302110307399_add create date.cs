namespace Project_Sem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcreatedate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "CreateDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "CreateDate");
        }
    }
}
