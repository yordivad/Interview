#module nuget:?package=Cake.DotNetTool.Module
#addin nuget:?package=Cake.Docker
#tool nuget:?package=GitVersion.CommandLine



var target = Argument("target", "default");
var configuration = Argument("configuration", "Release");
var solution = Argument("solution", "Epic.Interview.sln");
var artifacts = Argument("artifacts", "./artifacts");
var sonarkey = EnvironmentVariable("SONARKEY") ?? "";
var nugetkey = EnvironmentVariable("NUGETKEY") ?? "";
var amazonER = EnvironmentVariable("AMAZONKEY") ??  "";
var version = "0.0.1";


Task("analysis-begin").Does(()=> {
    var setting = new DotNetCoreToolSettings {
        ArgumentCustomization = 
            args => args.Append("begin")
                        .Append("/k:RoyGI_Interview")
                        .Append("/n:Interview")
                        .Append("/v:{0}",version )
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
        using(var process = StartAndReturnProcess("nbgv",  
            new ProcessSettings{ Arguments = "get-version -v NuGetPackageVersion", RedirectStandardOutput = true }))
        {
           version = process.GetStandardOutput().First();
        }
    }
    catch(Exception e) {
        Information("version error {0}", e.Message);
    }
  
    Information(version);
});

Task("package").Does(() => {
      var settings = new DotNetCorePackSettings
         {
            ArgumentCustomization = 
                    args => args.Append($"/p:Version={version}")
                                .Append($"/p:IncludeSymbols=true")
                                .Append("/p:SymbolPackageFormat=snupkg"),
            Configuration = configuration,
            OutputDirectory = artifacts
         };

        DotNetCorePack(solution, settings);
});


Task("push").Does(() => {

     var settings = new DotNetCoreNuGetPushSettings
     {
         Source = "https://api.nuget.org/v3/index.json",
         ApiKey = nugetkey
     };
     
     DotNetCoreNuGetPush( "./artifacts/*.nupkg", settings);
});


Task("restore").Does(()=> { 
    DotNetCoreRestore(solution); 
});

Task("clean").Does(() =>{
    CleanDirectories("./artifacts");
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
        var server_setting = new DockerImageBuildSettings { 
            Tag = new[] {$"server:latest"}, 
            File="docker/server/Dockerfile" 
        };
        DockerBuild(server_setting,".");
        DockerTag($"server:latest", $"{amazonER}/server:{version}");
        DockerPush($"{amazonER}/server:{version}");
 
        var web_setting = new DockerImageBuildSettings{  
            Tag = new[] {$"web:latest" },
            File="docker/web/Dockerfile"
        };
        DockerBuild(web_setting, ".");
        DockerTag($"web:latest", $"{amazonER}/web:{version}");
        DockerPush($"{amazonER}/web:{version}");
    });
    
    
    

Task("default")
    .IsDependentOn("clean")
    .IsDependentOn("restore")
    .IsDependentOn("version")
    .IsDependentOn("analysis-begin")
    .IsDependentOn("build")
    .IsDependentOn("test")
    .IsDependentOn("analysis-end")
    .IsDependentOn("package")
    .IsDependentOn("push")
    .IsDependentOn("docker");
    
RunTarget(target);