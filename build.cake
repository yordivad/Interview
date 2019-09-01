#module nuget:?package=Cake.DotNetTool.Module&version=0.3.0

#addin nuget:?package=Cake.Docker&version=0.10.1

#tool nuget:?package=GitVersion.CommandLine

var target = Argument("target", "default");
var configuration = Argument("configuration", "Release");
var solution = Argument("solution", "Epic.Interview.sln");

task("test").Does(()=> {
    var setting = new DotNetCoreTestSetting({
        ArgumentCustomization = args => 
            args.Append("/p:CollectCoverage=true")
                .Append("/p:CoverletOutput=coverage")
                .Append("/p:CoverletOutputFormat=opencover")
    });

    DotNetCoreTest(solution, setting);    
});

task("version").Does(() => {
    var setting = new GitVersionSetting {};
    var version = GitVersion(setting);
});

task("restore").Does(()=> { 
    DotNetCoreRestore(solution); 
});

task("quality").Does(()=> {

});

task("clean").Does(() =>{
    CleanDirectories(string.Format("./**/obj/{0}", configuration));
    CleanDirectories(string.Format("./**/bin/{0}", configuration));
    DotNetCoreClean(solution);
});

Task("build").Does(()=> {
    var setting = new DotNetCoreBuildSettings {
        configuration = configuration,
        NoRestore = false
    };
    
    DotNetCoreBuild(solution, setting);
});

Task("docker")
    .Does(()=> {
        var setting = new DockerImageBuildSettings{ Tag = new[] {"epic-interview:latest" }};
        DockerBuild(setting, ".");
    });

Task("default")
    .IsDependentOn("clean")
    .IsDependentOn("restore")
    .IsDependentOn("version")
    .IsDependentOn("build")
    .IsDependentOn("test")
    .IsDependentOn("docker");
    
RunTarget(target);