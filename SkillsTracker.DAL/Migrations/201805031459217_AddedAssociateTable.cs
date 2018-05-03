namespace SkillsTracker.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAssociateTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Associates",
                c => new
                    {
                        Associate_ID = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Mobile = c.String(),
                        Picture = c.String(),
                        Status_Green = c.Boolean(nullable: false),
                        Status_Blue = c.Boolean(nullable: false),
                        Status_Red = c.Boolean(nullable: false),
                        Level_1 = c.Boolean(nullable: false),
                        Level_2 = c.Boolean(nullable: false),
                        Level_3 = c.Boolean(nullable: false),
                        Remark = c.String(),
                        Strength = c.String(),
                        Weakness = c.String(),
                    })
                .PrimaryKey(t => t.Associate_ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Associates");
        }
    }
}
