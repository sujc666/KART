using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[InitializeOnLoad]
public class AutoSave
{
    static double saveInterval = 120; // 间隔：300 秒 = 5 分钟
    static double nextSaveTime;

    static AutoSave()
    {
        nextSaveTime = EditorApplication.timeSinceStartup + saveInterval;
        EditorApplication.update += AutoSaveUpdate;
    }

    static void AutoSaveUpdate()
    {
        if (EditorApplication.timeSinceStartup >= nextSaveTime)
        {
            SaveScene();
            nextSaveTime = EditorApplication.timeSinceStartup + saveInterval;
        }
    }

    static void SaveScene()
    {
        if (EditorApplication.isPlaying) return; // 不在播放时保存

        var scene = EditorSceneManager.GetActiveScene();
        if (scene.isDirty) // 场景有改动才保存
        {
            EditorSceneManager.SaveScene(scene);
            AssetDatabase.SaveAssets();
            Debug.Log($"[AutoSave] Scene saved at {System.DateTime.Now:T}");
        }
    }
}