using UnityEditor;
using UnityEditor.SceneManagement;

[InitializeOnLoad]
public class StartupSceneLoader
{
    static StartupSceneLoader()
    {
        string scenePath = "Assets/WeaponVFX/Scenes/Scene_ErhanVFX.unity";
        EditorSceneManager.sceneOpened += OnSceneOpened;
        if (EditorSceneManager.GetActiveScene().path != scenePath)
        {
            EditorSceneManager.OpenScene(scenePath);
        }
    }
	private static void OnSceneOpened(Scene scene, OpenSceneMode mode)
    {
        Debug.Log($"Scene opened: {scene.name}");

        // Sahneye ait tüm bağımlılıkları bul
        string[] dependencies = AssetDatabase.GetDependencies(scene.path, true);

        Debug.Log($"Found {dependencies.Length} dependencies for the scene.");

        foreach (string dependency in dependencies)
        {
            // Her bağımlılığı yükle
            Object asset = AssetDatabase.LoadAssetAtPath<Object>(dependency);
            if (asset == null)
            {
                Debug.LogWarning($"Could not load dependency: {dependency}");
            }
            else
            {
                Debug.Log($"Loaded dependency: {dependency}");
            }
        }

        Debug.Log("All scene dependencies have been loaded.");
    }
}