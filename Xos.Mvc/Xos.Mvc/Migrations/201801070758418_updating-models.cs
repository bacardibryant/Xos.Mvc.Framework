namespace Xos.Mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatingmodels : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AnotherModels", newName: "SampleModels");
            AddColumn("dbo.SampleModels", "ItemName", c => c.String());
            DropColumn("dbo.SampleModels", "Name");
            DropTable("dbo.AppModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AppModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemName = c.String(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        CreatedBy = c.String(maxLength: 250),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifiedBy = c.String(maxLength: 250),
                        LastModifiedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.SampleModels", "Name", c => c.String());
            DropColumn("dbo.SampleModels", "ItemName");
            RenameTable(name: "dbo.SampleModels", newName: "AnotherModels");
        }
    }
}
