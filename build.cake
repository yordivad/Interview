#module nuget:?package=Cake.DotNetTool.Module&version=0.3.0

#addin nuget:?package=Cake.SemVer
#addin nuget:?package=semver&version=2.0.4
#addin nuget:?package=Cake.Docker&version=0.10.1

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");


Task("DockerBuild")
    .Does(()=> {
        var setting = new DockerImageBuildSettings{ Tag = new[] {"epic-interview:latest" }};
        DockerBuild(setting, ".");
    });


Task("Default")
    .Description("This is the default task which will be ran if no specific target is passed in.")
    .IsDependentOn("DockerBuild");
    

RunTarget(target);