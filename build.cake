#module nuget:?package=Cake.DotNetTool.Module
#addin nuget:?package=Cake.Docker
#tool nuget:?package=GitVersion.CommandLine



var target = Argument("target", "default");
var configuration = Argument("configuration", "Release");
var solution = Argument("solution", "Epic.Interview.sln");
var sonarkey = Argument("sonarkey", "5a9ebeed2b5d54f9f846cfc3d8f998410c88c789");


Task("analysis-begin").Does(()=> {
    var setting = new DotNetCoreToolSettings {
        ArgumentCustomization = 
            args => args.Append("begin")
                        .Append("/k:RoyGI_Interview")
                        .Append("/n:Interview")
                        .Append("/v:1.0.0.1")
                        .Append("/d:sonar.host.url=https://sonarcloud.io")
                        .Append("/d:sonar.login={0}",sonarkey)
                        .Append("/o:roygi")
    };
    
    DotNetCoreTool("sonarscanner", setting);
});

Task("analysis-end").Does(()=> {
   var setting = new DotNetCoreToolSettings {
        ArgumentCustomization = 
           args => args.Append("end")
                       .Append("/d:sonar.login={0}",sonarkey)
    };
    
    DotNetCoreTool("sonarscanner", setting);
});

Task("test").Does(() => {
    var setting = new DotNetCoreTestSettings();
    DotNetCoreTest(solution, setting);    
});

Task("version").Does(() => {
    try {
        var setting = new GitVersionSettings {
            UpdateAssemblyInfo = false
        };
        var version = GitVersion(setting);
        Information(version);
    }
    catch(Exception e) {
        Information(e);
    }
});

Task("restore").Does(()=> { 
    DotNetCoreRestore(solution); 
});

Task("clean").Does(() =>{
    CleanDirectories(string.Format("./**/obj/{0}", configuration));
    CleanDirectories(string.Format("./**/bin/{0}", configuration));
});

Task("build").Does(()=> {
    var setting = new DotNetCoreBuildSettings {
        Configuration = configuration,
        NoRestore = true
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
    .IsDependentOn("analysis-begin")
    .IsDependentOn("build")
    .IsDependentOn("test")
    .IsDependentOn("analysis-end");
    
RunTarget(target);