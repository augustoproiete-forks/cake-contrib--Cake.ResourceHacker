#load nuget:?package=Cake.Recipe&version=1.0.0

Environment.SetVariableNames();

BuildParameters.SetParameters(
    context: Context,
    buildSystem: BuildSystem,
    sourceDirectoryPath: "./src",
    title: "Cake.ResourceHacker",
    repositoryOwner: "cake-contrib",
    repositoryName: "Cake.ResourceHacker",
    appVeyorAccountName: "cakecontrib",
	shouldRunDupFinder: false,
    shouldRunInspectCode: false,
	shouldRunCodecov: false,
    shouldRunGitVersion: true);

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(
    context: Context,
    dupFinderExcludePattern: new string[] { BuildParameters.RootDirectoryPath + "/src/Cake.ResourceHacker.Tests/*.cs" },
    testCoverageFilter: "+[*]* -[nunit.*]* -[Cake.Core]* -[Cake.Testing]* -[*.Tests]* -[NUnit3.*]*",
    testCoverageExcludeByAttribute: "*.ExcludeFromCodeCoverage*",
    testCoverageExcludeByFile: "*/*Designer.cs;*/*.g.cs;*/*.g.i.cs");
Build.RunDotNetCore();
