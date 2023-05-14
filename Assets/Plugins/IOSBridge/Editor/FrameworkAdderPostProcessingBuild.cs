#if UNITY_IOS
using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;

namespace IOSBridge
{
    public static class FrameworkAdderPostProcessingBuild
    {
        [PostProcessBuild]
        public static void AddFrameworksToXcode(BuildTarget buildTarget, string pathToProject)
        {
            if(buildTarget != BuildTarget.iOS) return;

            PBXProject project = new PBXProject();
            string sPath = PBXProject.GetPBXProjectPath(pathToProject);
            project.ReadFromFile(sPath);
            string frameworkTargetGuid = project.GetUnityFrameworkTargetGuid();
            
            //In this place you can write all frameworks which you want to add in the UnityFrameworks
            project.AddFrameworkToProject(frameworkTargetGuid, "AdSupport.framework", false);
            project.AddFrameworkToProject(frameworkTargetGuid, "iAd.framework", false);
            project.AddFrameworkToProject(frameworkTargetGuid, "Photos.framework", false);
            
            File.WriteAllText(sPath, project.WriteToString());
        }
    }
}
#endif
