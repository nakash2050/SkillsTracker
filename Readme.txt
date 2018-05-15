*******************Full Stack Developer Final Project - Skills Tracker*******************

--------------------------------------------------------------------------------------------------------------------------------------------
Important
--------------------------------------------------------------------------------------------------------------------------------------------
GitHub URL							: 	https://github.com/nakash2050/SkillsTracker.git
CruiseControl URL on Cloud Machine	: 	http://localhost/ccnet/ViewFarmReport.aspx
SkillsTracker SPA Production URL	:	http://localhost/SkillsTracker/SPA
SkillsTracker API Production URL	:	http://localhost/SkillsTracker/API/api


*******************************************************************************************************************************************
1. Unzip the file. The project gets extracted.
2. Execute the below steps in order.

------------------------------------------------------------------------------------------
Steps to configure database
------------------------------------------------------------------------------------------
1. Open "SQL Server Management Studio"
2. Connect to the database.
3. In the "SkillsTracker.StoredProcedures" folder, execute the following in order.
		a. 01_Create_Database_SkillsTracker.sql (This will create the "SkillsTracker" database)
		b. 02_Create_Tables_SP_And_Seed_Database.sql (This will create the tables, seed the database and add necessary permissions
			This script also contains the Stored Procedure to get the dashboard data)


------------------------------------------------------------------------------------------
Steps to build Web API project
------------------------------------------------------------------------------------------
1. Open Visual Studio in Administrator mode.
2. Browse to the solution file i.e. "SkillsTracker.sln"
3. If there is any change in the database server, you need to change in the connection string in 4 projects
		a. SkillsTracker.API - Web.config
		b. SkillsTracker.DAL - App.config (not necessary unless you are adding an Entity migration from Package Manager Console)
		c. SkillsTracker.PerformanceTest (SkillsTracker.NBench) - App.config
		d. SkillsTracker.NUnitTests - App.config
		e. SkillsTracker.Tests - App.config
	
Connection String:
------------------
<add name="SkillsTrackerContext" connectionString="Data Source=<Add_Your_Server_Here>;Initial Catalog=SkillsTracker;Integrated Security=True" providerName="System.Data.SqlClient" />
	
4. Right-click on the solution and click "Build Soultion". The necessary packages would be downloaded.
5. The Web API project is configured with the local IIS. Make sure you open the solution in Visual Studio Administrator mode.
6. If you want to run the project on IISExpress, then follow the steps given below:
		a. Double-click on the "Properties" of "SkillsTracker.API" project.
		b. Click on the "Web" tab on the left-pane.
		c. Select "IISExpress" under "Servers" section.
		d. Uncheck "Enable Edit and Continue" in the "Debuggers" section.
7. Right-click on "SkillsTracker.API" project and select "Set as StartUp project"
8. Click on "Run" to launch the API application.
9. You can access the API configured in IIS via http://localhost/SkillsTracker.API/api/<apiname>


------------------------------------------------------------------------------------------
Steps to build Angular SPA project
------------------------------------------------------------------------------------------
11. Open Visual Studio Code (VSCode) and browse to the "SkillsTracker.SPA" folder.
12. In VSCode menu, click on View -> Integrated Terminal. Integrated Terminal will be displayed.
13. Type the command "npm install" and click "Enter" key. The node packages will be downloaded.
14. Type the command "ng serve". The project will be built successfully.
15. Open "Google Chrome" browser and type in "http://localhost:4200" in the address bar.
16. The "Skills Tracker" application would be launched.

Note: For the Web API project, if you have changed from localhost to IISExpress, you need to change the 
	  "baseApiUrl" key in the "environment.ts" file of the Angular project as follows
	  
					export const environment = {
					  production: false,
					  baseApiUrl: 'http://localhost/SkillsTracker.API/api/'
					};

------------------------------------------------------------------------------------------
Miscellaneous Information:
------------------------------------------------------------------------------------------
1. Code Coverage"
		a. The "SkillsTracker.CodeCoverage" folder has a "Readme.txt" file which includes details on how to run the process.
		b. I have generated an actual Report which is available in the "CodeCoverageReport" folder.

2. Load Testing"
		a. The "SkillsTracker.LoadTest" folder has a "Readme.txt" file which includes details on how to run the process.
		b. I have generated an actual Report and Test Plan in the "Reports" and "TestPlan" folders respectively.
		
3. PerformanceTest Testing:
		a. The "SkillsTracker.NBench" folder has a "Readme.txt" file which includes details on how to run the process.
		b. I have generated an actual Performance Test Report which is available in the "PerformanceReport" folder.

3. Continuous Integration:
		a. The "SkillsTracker.Build" folder has a "Readme.txt" file which includes details on the build process.
		b. I have placed a document containing the screenshots of the CruiseControl.NET server.

		























