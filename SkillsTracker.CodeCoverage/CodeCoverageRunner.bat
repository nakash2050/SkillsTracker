set PATH=%PATH%;..\packages\OpenCover.4.6.519\tools;..\packages\ReportGenerator.3.1.2\tools;
set msTestPath=C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\mstest.exe
set unitTestPath=..\SkillsTracker.Tests\bin\Debug\SkillsTracker.Tests.dll
set unitTestResultsFolder=UnitTestResults
set unitTestResults=%unitTestResultsFolder%\.trx
set codeCoverageReportFolder=CodeCoverageReport

rd /s /q %unitTestResultsFolder%
rd /s /q %codeCoverageReportFolder%

mkdir %unitTestResultsFolder%

OpenCover.Console.exe -register:user -target:"%msTestPath%" -targetargs:" /testcontainer:\"..\SkillsTracker.Tests\bin\Debug\SkillsTracker.Tests.dll\" /resultsfile:%unitTestResults%" -mergebyhash -filter:"+[*]* -[SkillsTracker.DAL]SkillsTracker.DAL.Migrations.* -[SkillsTracker.API]SkillsTracker.API.Utilities.* -[SkillsTracker.API]*WebApiConfig -[SkillsTracker.API]*GlobalExceptionHandler -[SkillsTracker.API]*WebApiApplication" -output:%unitTestResultsFolder%\SkillsTrackerCoverageReport.xml

ReportGenerator.exe -reports:"%unitTestResultsFolder%\SkillsTrackerCoverageReport.xml" -targetdir:"%codeCoverageReportFolder%"



