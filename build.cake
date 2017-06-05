#tool "nuget:?package=xunit.runner.console"
//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = "Release";
var solution = "./FluentGuard Library Build.sln";

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

// Define directories.
var buildDir = Directory("./Org.Edgerunner.FluentGuard/bin") + Directory(configuration);

// Define assembly info
var assemblyInfo = ParseAssemblyInfo("./SolutionInfo.cs");
var assemblyVersion = assemblyInfo.AssemblyVersion;
var version = assemblyVersion.Split('.');
var versionMajor = version[0];
var versionMinor = version[1];
var now = DateTime.Now;
var nugetVersion = string.Format("{0}.{1}.{2}{3}-beta", versionMajor, versionMinor, now.ToString("yy"), now.DayOfYear);
var buildVersion = string.Format("{0}.{1}.{2}{3}.{4}", versionMajor, versionMinor, now.ToString("yy"), now.DayOfYear, now.ToString("HHmm"));

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>
{
    CleanDirectory(buildDir);
});

Task("Restore NuGet Packages")
    .IsDependentOn("Clean")
    .Does(() =>
{
    NuGetRestore(solution);
});

Task("Update Version Info")
    .IsDependentOn("Restore NuGet Packages")
    .Does(() =>
{
    Information("Build version set to: {0}", buildVersion);
	var info = new AssemblyInfoSettings();
	info.Version = buildVersion;
	info.FileVersion = buildVersion;
	info.InformationalVersion = buildVersion;
	CreateAssemblyInfo("./SolutionInfo.cs", info);
});

Task("Build Framework Version 4.0")
    .IsDependentOn("Update Version Info")
    .Does(() =>
{
	DotNetBuild(solution, settings =>
    settings.SetConfiguration("Release Net40")
		.SetVerbosity(Cake.Core.Diagnostics.Verbosity.Minimal)
        .WithTarget("Build")
        .WithProperty("TreatWarningsAsErrors","true"));
});

Task("Build Framework Version 4.5")
    .IsDependentOn("Update Version Info")
    .Does(() =>
{
	DotNetBuild(solution, settings =>
    settings.SetConfiguration("Release Net45")
		.SetVerbosity(Cake.Core.Diagnostics.Verbosity.Minimal)
        .WithTarget("Build")
        .WithProperty("TreatWarningsAsErrors","true"));
});

Task("Build Framework Version 4.6")
    .IsDependentOn("Update Version Info")
    .Does(() =>
{
	DotNetBuild(solution, settings =>
    settings.SetConfiguration("Release Net46")
		.SetVerbosity(Cake.Core.Diagnostics.Verbosity.Minimal)
        .WithTarget("Build")
        .WithProperty("TreatWarningsAsErrors","true"));
});

//Task("Run-Unit-Tests")
//    .IsDependentOn("Build40")
//    .Does(() =>
//{
//	var testAssemblies = GetFiles("./**/bin/" + configuration + "/*.Tests.dll");
//	XUnit2(testAssemblies,
//		 new XUnit2Settings {
//			Parallelism = ParallelismOption.All,
//			HtmlReport = true,
//			NoAppDomain = true,
//			OutputDirectory = "./build"
//		});
//});

Task("Build Nuget Package")
	.IsDependentOn("Build Framework Version 4.0")
	.IsDependentOn("Build Framework Version 4.5")
	.IsDependentOn("Build Framework Version 4.6")
	.Does(() =>
{
var nuGetPackSettings   = new NuGetPackSettings {
                                     Version                 = nugetVersion,
                                     OutputDirectory         = "./nuget"
                                 };

     NuGetPack("./Edgerunner.FluentGuard.nuspec", nuGetPackSettings);
});

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("Build Nuget Package");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
