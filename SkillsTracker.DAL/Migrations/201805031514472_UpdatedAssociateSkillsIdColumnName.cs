namespace SkillsTracker.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedAssociateSkillsIdColumnName : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.AssociateSkills", name: "AssociateSkillsId", newName: "Associate_Skills_ID");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.AssociateSkills", name: "Associate_Skills_ID", newName: "AssociateSkillsId");
        }
    }
}
