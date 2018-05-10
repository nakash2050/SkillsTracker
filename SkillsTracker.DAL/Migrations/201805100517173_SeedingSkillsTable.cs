namespace SkillsTracker.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedingSkillsTable : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO dbo.Skills(Skill_Name) VALUES
                ('Other'),
                ('Confidence'),
                ('Aptitude'),
                ('Logic'),
                ('Communication'),
                ('Spoken'),
                ('SCRUM'),
                ('PM'),
                ('Testing'),
                ('Jenkins'),
                ('Bit Bucket'),
                ('SVN'),
                ('GIT'),
                ('CI'),
                ('DevOps'),
                ('Spring Caching'),
                ('Hibernate'),
                ('XML'),
                ('JSON'),
                ('JAX-RS'),
                ('Spring Restful'),
                ('C#'),
                ('Java'),
                ('Spring MVC'),
                ('Spring'),
                ('React'),
                ('Restful'),
                ('Angular 4'),
                ('Angular 2'),
                ('Angular 1'),
                ('JQuery'),
                ('Javascript'),
                ('Bootstrap'),
                ('CSS3'),
                ('HTML5')
            ");
        }

        public override void Down()
        {
            @Sql("DELETE FROM dbo.Skills");
        }
    }
}
