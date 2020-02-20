namespace CrmBL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CrmRealEstate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RealEstates", "Type", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RealEstates", "Type");
        }
    }
}
