#module nuget:?package=Cake.DotNetTool.Module
#addin nuget:?package=Cake.Docker

var target = Argument("target", "default");
var configuration = Argument("configuration", "Release");
var solution = Argument("solution", "Epic.Interview.sln");
var artifacts = Argument("artifacts", "./.artifacts");
var sonarkey = EnvironmentVariable("SONARKEY") ?? "";
var ApiKey = EnvironmentVariable("APIKEY") ?? "";

var branch = EnvironmentVariable("CIRCLE_BRANCH") ?? "develop";
var version = "0.0.1";



Task("analysis-begin").Does(()=> {
    var setting = new DotNetCoreToolSettings {
        ArgumentCustomization = 
            args => args.Append("begin")
                        .Append("/k:RoyGI_Interview")
                        .Append("/n:Interview")
                        .Append("/v:{0}",version )
                        .Append("/d:sonar.cs.opencover.reportsPaths=./TestResults/coverage.opencover.xml")
                        .Append("/d:sonar.test.exclusions=test/**")
                        .Append("/d:sonar.exclusions=data/**")
                        .Append("/d:sonar.branch.name={0}", branch)
                        .Append("/d:sonar.links.ci=https://circleci.com/gh/RoyGI")
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
    var setting = new DotNetCoreTestSettings{
        ArgumentCustomization = args => {
                return args.Append("/p:CollectCoverage=true")
                           .Append("/p:CoverletOutputFormat=opencover")
                           .Append("/p:CoverletOutput=../../TestResults/");
        },
        Configuration = configuration,
        Logger = "trx",
        ResultsDirectory="./TestResults"
    };
    
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

Task("pack").Does(() => {
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
           Source = "https://api.bintray.com/nuget/roygi/mlibrary",
           ApiKey = $"roygi:{ApiKey}"
       };
       
    DotNetCoreNuGetPush( "./.artifacts/*.nupkg", settings);
});


Task("restore").Does(()=> { 
    DotNetCoreRestore(solution); 
});

Task("clean").Does(() =>{
    CleanDirectories("./.artifacts");
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


    
Task("default")
        .IsDependentOn("clean")
        .IsDependentOn("restore")
        .IsDependentOn("version")
        .IsDependentOn("analysis-begin")
        .IsDependentOn("build")
        .IsDependentOn("test")
        .IsDependentOn("analysis-end")
        .IsDependentOn("pack")
        .IsDependentOn("push");
        
Task("compile")
        .IsDependentOn("clean")
        .IsDependentOn("restore")
        .IsDependentOn("build");
        
Task("verify")
        .IsDependentOn("clean")
        .IsDependentOn("restore")
        .IsDependentOn("build")
        .IsDependentOn("test");
             
RunTarget(target);