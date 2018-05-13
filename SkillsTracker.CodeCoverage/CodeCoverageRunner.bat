set PATH=%PATH%;C:\Users\Nakash\AppData\Local\Apps\OpenCover;G:\Softwares\ReportGenerator;
set msTestPath=C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\mstest.exe
set unitTestPath=..\SkillsTracker.Tests\bin\Debug\SkillsTracker.Tests.dll
set unitTestResultsFolder=UnitTestResults
set unitTestResults=%unitTestResultsFolder%\.trx
set codeCoverageReportFolder=CodeCoverageReport

rd /s /q %unitTestResultsFolder%
rd /s /q %codeCoverageReportFolder%

mkdir %unitTestResultsFolder%

OpenCover.Console.exe -register:user -target:"%msTestPath%" -targetargs:" /testcontainer:\"..\SkillsTracker.Tests\bin\Debug\SkillsTracker.Tests.dll\" /resultsfile:%unitTestResults%" -mergebyhash -output:%unitTestResultsFolder%\SkillsTrackerCoverageReport.xml

ReportGenerator.exe -reports:"%unitTestResultsFolder%\SkillsTrackerCoverageReport.xml" -targetdir:"%codeCoverageReportFolder%"



