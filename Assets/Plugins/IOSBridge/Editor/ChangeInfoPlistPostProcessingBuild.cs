#if UNITY_IOS
using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;

namespace IOSBridge
{
    public static class ChangeInfoPlistPostProcessingBuild 
    {
        [PostProcessBuild]
        public static void ChangeXcodePlist(BuildTarget buildTarget, string pathToProject)
        {
            if(buildTarget != BuildTarget.iOS) return;
        
            string plistPath = pathToProject + "/Info.plist";
            PlistDocument plist = new PlistDocument();
            plist.ReadFromFile(plistPath);
        
            PlistElementDict rootDict = plist.root;
        
            //In this list you can write all dependency, which you want to add in the Info.plist file
            rootDict.SetString("NSPhotoLibraryAddUsageDescription", "Save to the photo album?");
        
            File.WriteAllText(plistPath, plist.WriteToString());
        }
    }
}
#endif