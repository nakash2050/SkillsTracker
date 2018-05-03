namespace SkillsTracker.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAssociateSkillsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssociateSkills",
                c => new
                    {
                        AssociateSkillsId = c.Int(nullable: false, identity: true),
                        Associate_ID = c.Int(nullable: false),
                        Skill_ID = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AssociateSkillsId)
                .ForeignKey("dbo.Associates", t => t.Associate_ID, cascadeDelete: true)
                .ForeignKey("dbo.Skills", t => t.Skill_ID, cascadeDelete: true)
                .Index(t => t.Associate_ID)
                .Index(t => t.Skill_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AssociateSkills", "Skill_ID", "dbo.Skills");
            DropForeignKey("dbo.AssociateSkills", "Associate_ID", "dbo.Associates");
            DropIndex("dbo.AssociateSkills", new[] { "Skill_ID" });
            DropIndex("dbo.AssociateSkills", new[] { "Associate_ID" });
            DropTable("dbo.AssociateSkills");
        }
    }
}
