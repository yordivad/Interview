#module nuget:?package=Cake.DotNetTool.Module&version=0.1.0
#tool dotnet:?package=GitVersion.Tool&version=4.0.1-beta1-58
#tool dotnet:?package=dotnet-xunit-to-junit&version=1.0.0
#r Newtonsoft.Json


var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");





Task("Default")
    

RunTarget(target);