namespace SkillsTracker.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedingAssociateTable : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO dbo.Associates(Associate_ID, Name, Email, Mobile, Picture, Status_Green, Status_Blue, Status_Red, Level_1, Level_2, Level_3, Remark, Strength, Weakness, Gender) VALUES 
                (295380, 'Nakash Sheikh', 'Nakash.Sheikh@cognizant.com', '9880940088', NULL, 1, 0, 0, 1, 0, 0, 'Remark for Nakash', 'Strengths of Nakash', 'Weakness of Nakash', 'M'),
                (295381, 'Tony Stark', 'Tony.Stark@cognizant.com', '9880940081', NULL, 0, 1, 0, 0, 1, 0, 'Remark for Tony', 'Strengths of Tony', 'Weakness of Tony', 'M'),
                (295382, 'Pepper Potts', 'Pepper.Potts@cognizant.com', '9880940082', NULL, 1, 0, 0, 0, 0, 1, 'Remark for Pepper', 'Strengths of Pepper', 'Weakness of Pepper', 'F'),
                (295383, 'Natasha Romanov', 'Natasha.Romanov@cognizant.com', '9880940083', NULL, 1, 0, 0, 1, 0, 0, 'Remark for Natasha', 'Strengths of Natash', 'Weakness of Natasha', 'F'),
                (295384, 'Bruce Banner', 'Bruce.Banner@cognizant.com', '9880940084', NULL, 0, 0, 1, 0, 1, 0, 'Remark for Bruce', 'Strengths of Bruce', 'Weakness of Bruce', 'M'),
                (295385, 'Jean Grey', 'Jean.Grey@cognizant.com', '9880940085', NULL, 0, 1, 0, 1, 0, 0, 'Remark for Jean', 'Strengths of Jean', 'Weakness of Jean', 'F'),
                (295386, 'Scott Summers', 'Scott.Summers@cognizant.com', '9880940086', NULL, 1, 0, 0, 0, 0, 1, 'Remark for Summers', 'Strengths of Summers', 'Weakness of Summers', 'M'),
                (295387, 'Steve Rogers', 'Steve.Rogers@cognizant.com', '9880940087', NULL, 1, 0, 0, 0, 1, 0, 'Remark for Steve', 'Strengths of Steve', 'Weakness of Steve', 'M'),
                (295388, 'Aurora Thomas', 'Aurora.Thomas@cognizant.com', '9880940089', NULL, 0, 1, 0, 0, 0, 1, 'Remark for Aurora', 'Strengths of Aurora', 'Weakness of Aurora', 'F'),
                (295389, 'Mathew Murdock', 'Mathew.Murdock@cognizant.com', '9880940091', NULL, 1, 0, 0, 1, 0, 0, 'Mathew for Jean', 'Strengths of Mathew', 'Weakness of Mathew', 'M'),
                (295390, 'Peter Parker', 'Peter.Parker@cognizant.com', '9880940092', NULL, 0, 0, 1, 0, 0, 1, 'Remark for Peter', 'Strengths of Peter', 'Weakness of Peter', 'M'),
                (295391, 'Mary Jane Watson', 'Mary.Jane@cognizant.com', '9880940093', NULL, 1, 0, 0, 1, 0, 0, 'Remark for Watson', 'Strengths of Watson', 'Weakness of Watson', 'F'),
                (295392, 'Felishia Hardy', 'Felishia.Hardy@cognizant.com', '9880940094', NULL, 0, 0, 1, 0, 0, 1, 'Remark for Felishia', 'Strengths of Felishia', 'Weakness of Felishia', 'F'),
                (295393, 'Charles Xavier', 'Charles.Xavier@cognizant.com', '9880940095', NULL, 1, 0, 0, 0, 1, 0, 'Remark for Charles', 'Strengths of Charles', 'Weakness of Charles', 'M'),
                (295394, 'Susan Storm', 'Susan.Storm@cognizant.com', '9880940096', NULL, 0, 1, 0, 0, 0, 1, 'Remark for Susan', 'Strengths of Susan', 'Weakness of Susan', 'F'),
                (295395, 'Richard Parker', 'Richard.Parker@cognizant.com', '9880940097', NULL, 1, 0, 0, 0, 1, 0, 'Remark for Richard', 'Strengths of Richard', 'Weakness of Richard', 'M'),
                (295396, 'Ben Grimm', 'Ben.Grimm@cognizant.com', '9880940098', NULL, 0, 0, 1, 1, 0, 0, 'Remark for Grimm', 'Strengths of Grimm', 'Weakness of Grimm', 'M'),
                (295397, 'Diana Hathway', 'Diana.Hathway@cognizant.com', '9880940099', NULL, 1, 0, 0, 0, 0, 1, 'Remark for Diana', 'Strengths of Diana', 'Weakness of Diana', 'F'),
                (295398, 'Jaden Smith', 'Jaden.Smith@cognizant.com', '9880940061', NULL, 1, 0, 0, 0, 1, 0, 'Remark for Jaden', 'Strengths of Jaden', 'Weakness of Jaden', 'M'),
                (295399, 'Robert Patrick', 'Robert.Patrick@cognizant.com', '9880940062', NULL, 0, 0, 1, 1, 0, 0, 'Remark for Patrick', 'Strengths of Patrick', 'Weakness of Patrick', 'M'),
                (295400, 'Julian Asange', 'Julian.Asange@cognizant.com', '9880940063', NULL, 0, 1, 0, 0, 1, 0, 'Remark for Julian', 'Strengths of Julian', 'Weakness of Julian', 'M')                                    
            ");
        }

        public override void Down()
        {
            Sql(@"DELETE FROM dbo.Associates");
        }
    }
}
