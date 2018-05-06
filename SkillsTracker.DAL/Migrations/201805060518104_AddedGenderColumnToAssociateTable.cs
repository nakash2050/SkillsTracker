namespace SkillsTracker.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGenderColumnToAssociateTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Associates", "Gender", c => c.String(maxLength: 1));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Associates", "Gender");
        }
    }
}
