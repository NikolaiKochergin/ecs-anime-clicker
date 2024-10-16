#addin nuget:?package=Cake.Unity&version=0.9.0

var target = Argument("target", "Build-WebGL");

Task("Clean-Artifacts")
    .Does(() =>
{
    Console.WriteLine("Build will be here.");
    CleanDirectory($"./artifacts");
});

Task("Build-WebGL")
    .IsDependentOn("Clean-Artifacts")
    .Does(() =>
{
    UnityEditor(
        2022, 3, 48, 'f', 1,
        new UnityEditorArguments
        {
            ProjectPath = "./src/ecs-anime-clicker",
            ExecuteMethod = "Editor.Builder.BuildWebGL",
            BuildTarget = BuildTarget.WebGL,
            LogFile = "./artifacts/unity.log",
        },
        new UnityEditorSettings
        {
            RealTimeLog = true,
        }
        );
});

RunTarget(target);