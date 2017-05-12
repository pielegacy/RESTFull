var target = Argument("target", "Default");

Task("Default")
  .Does(() =>
{
  Information("Building Solution...");
  DotNetCoreBuild("./RESTFull/");
  Information("Running Unit Tests...");
  MSTest("./TESTFull/bin/Debug/TestFull.dll");
  Information("Done!");
});

RunTarget(target);