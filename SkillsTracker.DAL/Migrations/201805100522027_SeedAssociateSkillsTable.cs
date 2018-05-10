namespace SkillsTracker.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedAssociateSkillsTable : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295380, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'HTML5'), 15)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295380, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'CSS3'), 10)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295380, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'Java'), 5)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295380, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'C#'), 15)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295380, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'Angular 1'), 10)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295380, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'Angular 2'), 10)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295380, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'React'), 5)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295380, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'Restful'), 14)

                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295381, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'Spring'), 6)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295381, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'Bootstrap'), 12)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295381, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'DevOps'), 15)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295381, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'Testing'), 10)

                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295382, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'Spring Restful'), 10)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295382, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'JQuery'), 11)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295382, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'Javascript'), 12)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295382, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'Jenkins'), 13)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295382, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'Bit Bucket'), 14)

                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295383, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'PM'), 14)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295383, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'DevOps'), 13)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295383, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'React'), 12)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295383, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'CSS3'), 11)

                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295384, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'DevOps'), 15)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295384, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'CSS3'), 10)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295384, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'Java'), 5)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295384, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'C#'), 15)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295384, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'Angular 1'), 10)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295384, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'Angular 2'), 10)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295384, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'React'), 5)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295384, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'Restful'), 14)

                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295385, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'SVN'), 9)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295385, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'GIT'), 8)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295385, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'JAX-RS'), 10)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295385, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'JSON'), 11)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295385, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'Testing'), 7)

                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295386, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'Hibernate'), 6)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295386, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'Testing'), 7)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295386, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'Logic'), 12)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295386, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'CI'), 13)

                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295387, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'Spring Restful'), 4)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295387, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'XML'), 17)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295387, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'Angular 4'), 12)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295387, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'Angular 2'), 14)

                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295388, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'HTML5'), 15)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295388, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'CSS3'), 10)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295388, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'Java'), 5)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295388, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'C#'), 15)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295388, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'DevOps'), 10)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295388, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'Angular 2'), 10)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295388, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'React'), 5)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295388, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'Restful'), 14)

                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295389, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'C#'), 15)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295389, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'Angular 1'), 10)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295389, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'Angular 2'), 10)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295389, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'React'), 5)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295389, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'Restful'), 14)

                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295390, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'C#'), 15)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295390, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'SVN'), 10)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295390, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'Spring Caching'), 10)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295390, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'JSON'), 5)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295390, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'Logic'), 14)

                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295391, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'HTML5'), 15)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295391, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'CSS3'), 10)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295391, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'Angular 1'), 10)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295391, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'Angular 2'), 10)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295391, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'Java'), 5)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295391, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'C#'), 15)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295391, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'React'), 5)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295391, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'Spring MVC'), 14)

                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295392, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'CI'), 15)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295392, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'DevOps'), 15)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295392, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'Bit Bucket'), 10)

                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295393, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'SCRUM'), 10)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295393, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'PM'), 15)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295393, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'Testing'), 19)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295393, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'DevOps'), 8)

                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295394, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'C#'), 10)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295394, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'HTML5'), 15)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295394, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'Bootstrap'), 19)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295394, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'CSS3'), 8)

                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295395, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'Aptitude'), 20)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295395, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'Communication'), 15)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295395, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'CI'), 19)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295395, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'JQuery'), 8)

                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295395, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'GIT'), 20)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295395, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'SCRUM'), 15)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295395, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'Restful'), 19)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295395, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'Angular 2'), 8)

                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295396, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'HTML5'), 15)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295396, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'CSS3'), 10)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295396, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'Angular 1'), 10)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295396, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'Angular 2'), 10)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295396, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'Java'), 5)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295396, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'C#'), 15)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295396, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'React'), 5)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295396, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'Restful'), 14)

                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295397, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'Angular 1'), 10)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295397, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'Angular 2'), 10)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295397, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'Java'), 5)

                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295398, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'SVN'), 10)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295398, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'Hibernate'), 10)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295398, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'Javascript'), 5)

                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295399, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'Confidence'), 10)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295399, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'Other'), 10)

                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295400, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'HTML5'), 15)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295400, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'CSS3'), 10)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295400, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'Angular 1'), 10)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295400, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'Angular 2'), 10)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295400, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'Java'), 5)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295400, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'C#'), 15)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295400, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'React'), 5)
                INSERT INTO dbo.AssociateSkills(Associate_ID, Skill_ID, SkillRating) VALUES(295400, (SELECT Skill_ID FROM dbo.Skills WHERE Skill_Name = 'Restful'), 14)
            ");
        }

        public override void Down()
        {
            Sql(@"DELETE FROM dbo.AssociateSkills");
        }
    }
}
