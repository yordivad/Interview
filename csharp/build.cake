#module nuget:?package=Cake.DotNetTool.Module
#addin nuget:?package=Cake.Docker

var target = Argument("target", "default");
var configuration = Argument("configuration", "Release");
var solution = Argument("solution", "Epic.Interview.sln");
var artifacts = Argument("artifacts", "./.artifacts");
var sonarKey = EnvironmentVariable("SONARKEY") ?? "";
var apiKey = EnvironmentVariable("APIKEY") ?? "";
var branch = EnvironmentVariable("BRANCH") ?? "master";
var version = EnvironmentVariable("VERSION") ?? "0.0.1";


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
                        .Append("/d:sonar.login={0}",sonarKey)
                        .Append("/o:roygi")
    };
    
    DotNetCoreTool("sonarscanner", setting);
});

Task("analysis-end").Does(()=> {
   var setting = new DotNetCoreToolSettings {
        ArgumentCustomization = 
           args => args.Append("end")
                       .Append("/d:sonar.login={0}",sonarKey)
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
           ApiKey = $"roygi:{apiKey}"
       };
       
    DotNetCoreNuGetPush( "./.artifacts/*.nupkg", settings);
});


Task("restore").Does(()=> { 
     var settings = new DotNetCoreRestoreSettings
     {
         Sources = new[] {"https://api.nuget.org/v3/index.json", "https://api.bintray.com/nuget/roygi/mlibrary"},
         PackagesDirectory = "./packages",
         Verbosity = DotNetCoreVerbosity.Quiet,
         Force = true,
         DisableParallel = false,
     };
     
    DotNetCoreRestore(solution, settings); 
});

Task("clean").Does(() =>{
    CleanDirectories("./.artifacts");
    CleanDirectories("./.migration");
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


Task("version").Does(() => {

        var settings = new ProcessSettings {
            Arguments = "gitversion /showvariable NuGetVersion",
            RedirectStandardOutput = true
        };

        using(var process = StartAndReturnProcess("dotnet",settings)) {
            version = process.GetStandardOutput().First();
        };

});


Task("migrate_default").Does(()=> {
    
     var settings = new DotNetCorePublishSettings
         {
             Configuration = "Release",
             OutputDirectory = "./.migration/"
         };
         
    DotNetCorePublish("./data/MCode.Interview.Data.App", settings);
    DotNetCoreExecute("./.migration/MCode.Interview.Data.App.dll");

});

    
Task("default")
        .IsDependentOn("clean")
        .IsDependentOn("restore")
        .IsDependentOn("version")
        .IsDependentOn("analysis-begin")
        .IsDependentOn("build")
        .IsDependentOn("test")
        .IsDependentOn("analysis-end");

Task("check")
        .IsDependentOn("clean")
        .IsDependentOn("restore")
        .IsDependentOn("build")
        .IsDependentOn("test");

Task("deploy")
        .IsDependentOn("version")
        .IsDependentOn("pack")
        .IsDependentOn("push");

Task("migrate")
        .IsDependentOn("migrate_default");

RunTarget(target);