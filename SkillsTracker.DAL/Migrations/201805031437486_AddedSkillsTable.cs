namespace SkillsTracker.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSkillsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        Skill_ID = c.Int(nullable: false, identity: true),
                        Skill_Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Skill_ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Skills");
        }
    }
}
