USE [SkillsTracker]
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[sp_GetDashboardData]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
  DROP PROCEDURE [dbo].[sp_GetDashboardData]
END
GO

CREATE PROCEDURE sp_GetDashboardData
AS
BEGIN
	SELECT Associate_ID [AssociateID], AST.Name, AST.Email, AST.Mobile, AST.Picture, 
	CASE 
		WHEN AST.Status_Green = 1 THEN 'GREEN'
		WHEN AST.Status_Blue = 1 THEN 'BLUE'
		WHEN AST.Status_Red = 1 THEN 'RED'
	END AS Status,
	Skills = STUFF  
	( 
		(
		SELECT DISTINCT ', '+ CAST(SK.Skill_Name AS VARCHAR(MAX)) FROM dbo.AssociateSkills ASK
		LEFT JOIN dbo.Skills SK
			ON ASK.Skill_ID = SK.Skill_ID
		WHERE ASK.Associate_ID = AST.Associate_ID   
		  FOR XMl PATH('')
		),1,1,''
	)
	FROM dbo.Associates AST  
	GROUP BY Associate_ID, AST.Name, AST.Email, AST.Mobile, AST.Picture, AST.Status_Green, AST.Status_Blue, AST.Status_Red
END