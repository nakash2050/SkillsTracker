**********************Continuous Integration with CruiseControl.NET**********************
1. CruiseControl.NET has been installed on the Cloud machine.
2. Browse to "http://localhost/ccnet/ViewFarmReport.aspx".
3. I have used NAnt integrated with Cruise Control for building and deploying the packages. The NAnt files are "base.build" and "deploy.build" respectively.
3. "APP-SkillsTracker-Build" is the build project which runs every hour. It could also be triggerred by clicking on "Force" button of the project.
4. "APP-SkillsTracker-Build" does the following:
		a. Downloads the code base from GitHub
		b. Builds the "SkillsTracker.API" project.
		c. Builds the "SkillsTracker.SPA" project (Angular)
		d. Creates the deployment packages.
		e. Runs the unit test cases.
5. "APP-SkillsTracker-Deploy" does the following:
		a. Updates the APP keys like Connection Strings etc. in the Web.config files
		b. Deploys the API and SPA packages to the virtual directories of IIS.
6. The CruiseControl server config file is available in the "config" folder.
7. Screenshots are available in "Continuous_Integration_with_Cruise_Control.docx"