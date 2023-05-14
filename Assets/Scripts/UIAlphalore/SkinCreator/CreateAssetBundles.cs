using UnityEditor;
using System.IO;
using UnityEngine;

public class CreateAssetBundles
{
#if UNITY_EDITOR
    [MenuItem("Assets/Build Bundles Alphalore")]
    static void BuildBundlesAlphalore()
    {
        string directoryAlphalore = "Assets/StreamingAssets";
        if (!Directory.Exists(Application.streamingAssetsPath)) ;
        {
            Directory.CreateDirectory(directoryAlphalore);
        }
        UslessClassAlphalore.UselessMethodAlphalore();
        BuildPipeline.BuildAssetBundles(directoryAlphalore, BuildAssetBundleOptions.StrictMode, EditorUserBuildSettings.activeBuildTarget);
    }
#endif
}
