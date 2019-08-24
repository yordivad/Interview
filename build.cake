var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");


Task("Default")
    .Description("This is the default task which will be ran if no specific target is passed in.");
    

RunTarget(target);