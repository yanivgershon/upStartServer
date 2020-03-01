namespace upStartServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixGUID : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Entities");
            AlterColumn("dbo.Entities", "Id", c => c.Guid(nullable: false, identity: true, defaultValueSql: "newsequentialid()"));
            AddPrimaryKey("dbo.Entities", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Entities");
            AlterColumn("dbo.Entities", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Entities", "Id");
        }
    }
}
