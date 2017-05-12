var target = Argument("target", "Default", "run_tests");

Task("Default")
  .Does(() =>
{
  // Build RESTFull by default
  Information("Building Solution...");
  DotNetCoreBuild("./RESTFull/");
  // Running tests
  if (run_tests != null)
  {
    Information("Running Unit Tests...");
    MSTest("./TESTFull/bin/Debug/TestFull.dll");
  }
  // Build EF Database
  Information("Done!");
});

RunTarget(target);