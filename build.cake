#tool "nuget:?package=xunit.runner.console"
//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
var solution = "./FluentGuard Library.sln";

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

// Define directories.
var buildPath = "./Org.Edgerunner.FluentGuard/bin/" + configuration;
var buildDir = Directory("./Org.Edgerunner.FluentGuard/bin") + Directory(configuration);

// Define assembly info
var assemblyInfo = ParseAssemblyInfo("./SolutionInfo.cs");
var assemblyVersion = assemblyInfo.AssemblyVersion;
var version = assemblyVersion.Split('.');
var versionMajor = version[0];
var versionMinor = version[1];
var now = DateTime.Now;
var nugetVersion = string.Format("{0}.{1}.{2}{3}", versionMajor, versionMinor, now.ToString("yy"), now.DayOfYear);
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
    settings.SetConfiguration(configuration)
		.SetVerbosity(Cake.Core.Diagnostics.Verbosity.Minimal)
        .WithTarget("Build")
        .WithProperty("NetFramework", "NET40")        
        .WithProperty("TreatWarningsAsErrors","true"));
});

Task("Build Framework Version 4.5")
    .IsDependentOn("Update Version Info")
    .Does(() =>
{
	DotNetBuild(solution, settings =>
    settings.SetConfiguration(configuration)
		.SetVerbosity(Cake.Core.Diagnostics.Verbosity.Minimal)
        .WithTarget("Build")
        .WithProperty("NetFramework", "NET45")
        .WithProperty("TreatWarningsAsErrors","true"));
});

Task("Build Framework Version 4.6")
    .IsDependentOn("Update Version Info")
    .Does(() =>
{
	DotNetBuild(solution, settings =>
    settings.SetConfiguration(configuration)
		.SetVerbosity(Cake.Core.Diagnostics.Verbosity.Minimal)
        .WithTarget("Build")
        .WithProperty("TreatWarningsAsErrors","true"));
});

//Task("Build Framework Version 4.7")
//    .IsDependentOn("Update Version Info")
//    .Does(() =>
//{
//	DotNetBuild(solution, settings =>
//    settings.SetConfiguration(configuration)
//		.SetVerbosity(Cake.Core.Diagnostics.Verbosity.Minimal)
//        .WithTarget("Build")
//        .WithProperty("NetFramework", "NET47")        
//        .WithProperty("TreatWarningsAsErrors","true"));
//});


Task("Build .Net Standard Version 1.4")
    .IsDependentOn("Update Version Info")
    .Does(() =>
{
	DotNetCoreBuild(solution, new DotNetCoreBuildSettings 
		{
			Framework = "netstandard1.4",
			Configuration = configuration,
			OutputDirectory = buildPath + "/netstd14/"
		});
});

Task("Build .Net Standard Version 1.6")
    .IsDependentOn("Update Version Info")
    .Does(() =>
{
	DotNetCoreBuild(solution, new DotNetCoreBuildSettings 
		{
			Framework = "netstandard1.6",
			Configuration = configuration,
			OutputDirectory = buildPath + "/netstd16/"
		});
});

Task("Build .Net Standard Version 2.0")
    .IsDependentOn("Update Version Info")
    .Does(() =>
{
	DotNetCoreBuild(solution, new DotNetCoreBuildSettings 
		{
			Framework = "netstandard2.0",
			Configuration = configuration,
			OutputDirectory = buildPath + "/netstd20/"
		});
});

Task("Run-Unit-Tests")
    .IsDependentOn("Build Framework Version 4.6")
    .Does(() =>
{
	var testAssemblies = GetFiles("./**/bin/" + configuration + "/*.Tests.dll");
	XUnit2(testAssemblies,
		 new XUnit2Settings {
			Parallelism = ParallelismOption.All,
			HtmlReport = false,
			NoAppDomain = true
		});
});

Task("Build Nuget Package")
	.IsDependentOn("Run-Unit-Tests")
	.IsDependentOn("Build Framework Version 4.0")
	.IsDependentOn("Build Framework Version 4.5")
	.IsDependentOn("Build Framework Version 4.6")
//	.IsDependentOn("Build Framework Version 4.7")
	.IsDependentOn("Build .Net Standard Version 1.4")
	.IsDependentOn("Build .Net Standard Version 1.6")
	.IsDependentOn("Build .Net Standard Version 2.0")
	.Does(() =>
{
var nuGetPackSettings   = new NuGetPackSettings {
                                     Version                 = nugetVersion,
									 Copyright               = string.Format("Thaddeus Ryker {0}", now.ToString("yyyy")),
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
