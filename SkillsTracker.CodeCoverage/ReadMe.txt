************************************************************SkillsTracker Code Coverage**********************************************************************
1. Unit tests are written in both MSTest and NUnit which is under "SkillsTracker.Tests" and "SkillsTracker.NUnitTests" folders respectively.
2. I have chosen MSTest as the test runner as I did not want to install NUnit runner which basically does the same job as MSTest, in order to avoid redundancy.
3. To run CodeCoverage, "OpenCover" has been used.
4. To generate the CodeCoverage results, "ResultsGenerator" has been used.
5. To analyze code coverage, execute the follwing steps:
		a. Build "SkillsTracker.Tests" project.
		b. Open command prompt and "CD" to "SkillsTracker.CodeCoverage" folder
		c. Trigger "CodeCoverageRunner.bat" file. This will create a "CodeCoverageReport" folder (which has been checked-in)
6. Open "CodeCoverageReport" folder and browse "index.htm" file in a browser.
7. CodeCoverage results are displayed.

