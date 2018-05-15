********************SkillsTracker Code Coverage********************
1. Unit tests are written in both MSTest and NUnit which are under "SkillsTracker.Tests" and "SkillsTracker.NUnitTests" folders respectively.
2. I have chosen MSTest as the test runner as I did not want to install NUnit runner which basically does the same job as MSTest, in order to avoid redundancy.
3. To run CodeCoverage, "OpenCover" has been used. (https://sourceforge.net/projects/opencover.mirror/files/4.6.519/)
4. To generate the CodeCoverage results, "ReportGenerator" has been used. (https://github.com/danielpalme/ReportGenerator/releases)
5. To analyze code coverage, execute the follwing steps:
		a. Build "SkillsTracker.Tests" project.
		b. Double click on the "CodeCoverageRunner.bat" file.
6. Open "CodeCoverageReport" folder and browse "index.htm" file in a browser.
7. CodeCoverage results are displayed.

Note: If the test cases are failing, it would be a problem with the connection string. 
	  Please change the connection string in the App.config file of "SkillsTracker.Tests" project to the below
	 
<add name="SkillsTrackerContext" connectionString="Data Source=FSD;Initial Catalog=SkillsTracker;Integrated Security=True" providerName="System.Data.SqlClient" />	 

