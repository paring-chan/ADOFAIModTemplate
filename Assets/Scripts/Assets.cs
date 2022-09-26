using System.IO;
using UnityEditor;
using UnityEngine;
using UnityModManagerNet;

namespace ExampleMod
{
    internal static class Assets
    {
        private static AssetBundle bundle;

        public static void Load(UnityModManager.ModEntry entry)
        {
            var assetBundlePath = Path.Combine(entry.Path, "assets.bundle");

            bundle = AssetBundle.LoadFromMemory(File.ReadAllBytes(assetBundlePath));
            
            entry.Logger.Log(string.Join(", ", bundle.GetAllAssetNames()));
        }

        public static void Unload()
        {
            bundle.Unload(true);
            
            bundle = null;
        }

        public static T LoadAsset<T>(string path) where T : Object
        {
#if UNITY_EDITOR
            return AssetDatabase.LoadAssetAtPath<T>(path);
#else
            return bundle.LoadAsset<T>(path);
#endif
        }
    }
}