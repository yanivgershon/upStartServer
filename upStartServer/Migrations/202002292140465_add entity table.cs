namespace upStartServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addentitytable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Entities",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true, defaultValueSql: "newsequentialid()"),
                        Name = c.String(),
                        Description = c.String(),
                        Amount = c.Int(nullable: false),
                        Date = c.Long(nullable: false),
                        IsPrivate = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Entities");
        }
    }
}
