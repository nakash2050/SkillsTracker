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
	DECLARE @TotalCandidates INT
	DECLARE	@TotalNumberOfFemaleCandidates INT
	DECLARE	@TotalNumberOfMaleCandidates INT
	DECLARE	@TotalNumberOfFreshers INT
	DECLARE @TotalNumberOfL1Candidates INT
	DECLARE @TotalNumberOfL2Candidates INT
	DECLARE @TotalNumberOfL3Candidates INT
	DECLARE @TotalNumberOfCandidatesRated INT
	DECLARE @TotalNumberOfFemaleCandidatesRated INT
	DECLARE @TotalNumberOfMaleCandidatesRated INT
	
	DECLARE @TotalHTML5Candidates INT
	DECLARE @TotalCSS3Candidates INT
	DECLARE @TotalJavaCandidates INT
	DECLARE @TotalCSharpCandidates INT
	DECLARE @TotalRestfulCandidates INT
	DECLARE @TotalAngular1Candidates INT
	DECLARE @TotalAngular2Candidates INT
	DECLARE @TotalReactCandidates INT

	SELECT @TotalCandidates = COUNT(*) FROM dbo.Associates

	SELECT @TotalNumberOfFemaleCandidates = COUNT(*) FROM dbo.Associates WHERE Gender = 'F'

	SELECT @TotalNumberOfMaleCandidates = COUNT(*) FROM dbo.Associates WHERE Gender = 'M'

	SELECT @TotalNumberOfFreshers = COUNT(*) FROM dbo.Associates WHERE Level_1 = 1

	SELECT @TotalNumberOfCandidatesRated = COUNT(DISTINCT(Associate_ID)) FROM dbo.AssociateSkills

	SELECT @TotalNumberOfFemaleCandidatesRated = COUNT(DISTINCT(ASTS.Associate_ID)) FROM dbo.AssociateSkills ASTS
		LEFT JOIN dbo.Associates AST ON ASTS.Associate_ID = AST.Associate_ID
	WHERE AST.Gender = 'F'

	SELECT @TotalNumberOfMaleCandidatesRated = COUNT(DISTINCT(ASTS.Associate_ID)) FROM dbo.AssociateSkills ASTS
		LEFT JOIN dbo.Associates AST ON ASTS.Associate_ID = AST.Associate_ID
	WHERE AST.Gender = 'M'

	SELECT @TotalNumberOfL1Candidates = @TotalNumberOfFreshers

	SELECT @TotalNumberOfL2Candidates = COUNT(*) FROM dbo.Associates WHERE Level_2 = 1

	SELECT @TotalNumberOfL3Candidates = COUNT(*) FROM dbo.Associates WHERE Level_3 = 1

	-- For Tiles
	SELECT
		@TotalCandidates AS [RegisteredCandidates],
		CAST(ROUND(CAST(@TotalNumberOfFemaleCandidates*100.0 / @TotalCandidates AS DECIMAL(10,2)), 0) AS INT) AS [PercentageOfFemaleCandidates],
		CAST(ROUND(CAST(@TotalNumberOfMaleCandidates*100.0 / @TotalCandidates AS DECIMAL(10,2)), 0) AS INT) AS [PercentageOfMaleCandidates],
		CAST(ROUND(CAST(@TotalNumberOfFreshers*100.0 / @TotalCandidates AS DECIMAL(10,2)), 0) AS INT) AS [PercentageOfFreshers],
		@TotalNumberOfCandidatesRated AS [CandidatesRated],
		CAST(ROUND(CAST(@TotalNumberOfFemaleCandidatesRated*100.0 / @TotalNumberOfCandidatesRated AS DECIMAL(10,2)), 0) AS INT) AS [PercentageOfFemaleCandidatesRated],
		CAST(ROUND(CAST(@TotalNumberOfMaleCandidatesRated*100.0 / @TotalNumberOfCandidatesRated AS DECIMAL(10,2)), 0) AS INT) AS [PercentageOfMaleCandidatesRated],
		CAST(ROUND(CAST(@TotalNumberOfL1Candidates*100.0 / @TotalCandidates AS DECIMAL(10,2)), 0) AS INT) AS [PercentageOfLevel1Candidates],
		CAST(ROUND(CAST(@TotalNumberOfL2Candidates*100.0 / @TotalCandidates AS DECIMAL(10,2)), 0) AS INT) AS [PercentageOfLevel2Candidates],
		CAST(ROUND(CAST(@TotalNumberOfL3Candidates*100.0 / @TotalCandidates AS DECIMAL(10,2)), 0) AS INT) AS [PercentageOfLevel3Candidates]

	-- For Chart
	SELECT @TotalHTML5Candidates = COUNT(*) FROM dbo.AssociateSkills ASK
	LEFT JOIN dbo.Skills SK
		ON ASK.Skill_ID = SK.Skill_ID
	WHERE SK.Skill_Name LIKE '%HTML5%'

	SELECT @TotalCSS3Candidates = COUNT(*) FROM dbo.AssociateSkills ASK
	LEFT JOIN dbo.Skills SK
		ON ASK.Skill_ID = SK.Skill_ID
	WHERE SK.Skill_Name LIKE '%CSS3%'

	SELECT @TotalJavaCandidates = COUNT(*) FROM dbo.AssociateSkills ASK
	LEFT JOIN dbo.Skills SK
		ON ASK.Skill_ID = SK.Skill_ID
	WHERE SK.Skill_Name LIKE '%Java%'

	SELECT @TotalCSharpCandidates = COUNT(*) FROM dbo.AssociateSkills ASK
	LEFT JOIN dbo.Skills SK
		ON ASK.Skill_ID = SK.Skill_ID
	WHERE SK.Skill_Name LIKE '%C#%'

	SELECT @TotalRestfulCandidates = COUNT(*) FROM dbo.AssociateSkills ASK
	LEFT JOIN dbo.Skills SK
		ON ASK.Skill_ID = SK.Skill_ID
	WHERE SK.Skill_Name LIKE '%Restful%'

	SELECT @TotalAngular1Candidates = COUNT(*) FROM dbo.AssociateSkills ASK
	LEFT JOIN dbo.Skills SK
		ON ASK.Skill_ID = SK.Skill_ID
	WHERE SK.Skill_Name LIKE '%Angular 1%'

	SELECT @TotalAngular2Candidates = COUNT(*) FROM dbo.AssociateSkills ASK
	LEFT JOIN dbo.Skills SK
		ON ASK.Skill_ID = SK.Skill_ID
	WHERE SK.Skill_Name LIKE '%Angular 2%'

	SELECT @TotalReactCandidates = COUNT(*) FROM dbo.AssociateSkills ASK
	LEFT JOIN dbo.Skills SK
		ON ASK.Skill_ID = SK.Skill_ID
	WHERE SK.Skill_Name LIKE '%React%'

	DECLARE @TotalSkillsCount INT
	SELECT @TotalSkillsCount = (@TotalHTML5Candidates + @TotalCSS3Candidates + @TotalJavaCandidates + @TotalCSharpCandidates + @TotalRestfulCandidates + @TotalAngular1Candidates + @TotalAngular2Candidates + @TotalReactCandidates)


	SELECT
		CAST(CAST(@TotalHTML5Candidates*100.0 / @TotalSkillsCount AS DECIMAL(10,2)) / 100 AS DECIMAL(10,2)) AS [PercentageOfHTML5Candidates],
		CAST(CAST(@TotalCSS3Candidates*100.0 / @TotalSkillsCount AS DECIMAL(10,2)) / 100 AS DECIMAL(10,2)) AS [PercentageOfCSS3Candidates],
		CAST(CAST(@TotalJavaCandidates*100.0 / @TotalSkillsCount AS DECIMAL(10,2)) / 100 AS DECIMAL(10,2)) AS [PercentageOfJavaCandidates],
		CAST(CAST(@TotalCSharpCandidates*100.0 / @TotalSkillsCount AS DECIMAL(10,2)) / 100 AS DECIMAL(10,2)) AS [PercentageOfCSharpCandidates],
		CAST(CAST(@TotalRestfulCandidates*100.0 / @TotalSkillsCount AS DECIMAL(10,2)) / 100 AS DECIMAL(10,2)) AS [PercentageOfRestfulCandidates],
		CAST(CAST(@TotalAngular1Candidates*100.0 / @TotalSkillsCount AS DECIMAL(10,2)) / 100 AS DECIMAL(10,2)) AS [PercentageOfAngular1Candidates],
		CAST(CAST(@TotalAngular2Candidates*100.0 / @TotalSkillsCount AS DECIMAL(10,2)) / 100 AS DECIMAL(10,2)) AS [PercentageOfAngular2Candidates],
		CAST(CAST(@TotalReactCandidates*100.0 / @TotalSkillsCount AS DECIMAL(10,2)) / 100 AS DECIMAL(10,2)) AS [PercentageOfReactCandidates]

	--For Table
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