#addin nuget:?package=Cake.Unity&version=0.9.0

var target = Argument("target", "Build-WebGL");

Task("Clean-Artifacts")
    .Does(() =>
{
    CleanDirectory($"./artifacts");
});
/*
Task("Find-Unity-Editor-2022.3.48")
    .Does(() =>
{
    var editor = FindUnityEditor(2022, 3, 48);
    if(editor != null)
        Information("Found Unity Editor {0} at path {1}", editor.Version, editor.Path);
    else
        Warning("Cannot find Unity Editor 2022.3.48");  
});
*/

Task("Build-WebGL")
    .IsDependentOn("Clean-Artifacts")
    //.IsDependentOn("Find-Unity-Editor-2022.3.48")
    .Does(() =>
{
    UnityEditor(
        //2022, 3, 48, 'f', 1,
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