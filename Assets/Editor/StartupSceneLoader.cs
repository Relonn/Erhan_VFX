using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

[InitializeOnLoad]
public class StartupSceneLoader
{
    const string scenePath = "Assets/Scenes/Scene_ErhanVFX.unity";

    static StartupSceneLoader()
    {
        EditorSceneManager.sceneOpened += OnSceneOpened;
        if (SceneManager.GetActiveScene().path != scenePath)
        {
            EditorSceneManager.OpenScene(scenePath);
        }
    }

    private static void OnSceneOpened(Scene scene, OpenSceneMode mode)
    {
        if (scene.path != scenePath)
        {
            EditorSceneManager.OpenScene(scenePath);
        }
        string[] dependencies = AssetDatabase.GetDependencies(scene.path, true);
        foreach (string dependency in dependencies)
        {
            Object asset = AssetDatabase.LoadAssetAtPath<Object>(dependency);
            if (asset == null)
            {
                Debug.LogWarning($"Could not load dependency: {dependency}");
            }
        }
        SceneManager.SetActiveScene(scene);
    }
}