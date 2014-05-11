namespace imgcrv.Presentation.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class crvPth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "originalPath", c => c.String());
            AddColumn("dbo.Images", "carvedPath", c => c.String());
            DropColumn("dbo.Images", "Path");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Images", "Path", c => c.String());
            DropColumn("dbo.Images", "carvedPath");
            DropColumn("dbo.Images", "originalPath");
        }
    }
}
