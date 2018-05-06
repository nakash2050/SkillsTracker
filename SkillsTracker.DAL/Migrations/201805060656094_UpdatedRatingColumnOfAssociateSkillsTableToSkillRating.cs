namespace SkillsTracker.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedRatingColumnOfAssociateSkillsTableToSkillRating : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AssociateSkills", "SkillRating", c => c.Int(nullable: false));
            DropColumn("dbo.AssociateSkills", "Rating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AssociateSkills", "Rating", c => c.Int(nullable: false));
            DropColumn("dbo.AssociateSkills", "SkillRating");
        }
    }
}
