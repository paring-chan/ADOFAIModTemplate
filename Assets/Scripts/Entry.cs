using UnityEngine;
using UnityModManagerNet;

namespace ExampleMod
{
    internal static class Entry
    {
        private static void Load(UnityModManager.ModEntry entry)
        {
            entry.OnToggle = (modEntry, b) =>
            {
                if (b) Start(modEntry);
                else Stop(modEntry);

                return true;
            };
        }

        private static Canvas canvas;

        private static void Start(UnityModManager.ModEntry entry)
        {
            Assets.Load(entry);

            canvas = Object.Instantiate(Assets.LoadAsset<GameObject>("assets/prefab/canvas.prefab")).GetComponent<Canvas>();
            
            Object.DontDestroyOnLoad(canvas.gameObject);
        }

        // ReSharper disable once UnusedParameter.Local
        private static void Stop(UnityModManager.ModEntry entry)
        {
            Assets.Unload();
            
            Object.Destroy(canvas.gameObject);

            canvas = null;
        }
    }
}