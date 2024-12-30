using UnityEditor;
using UnityEditor.SceneManagement;

[InitializeOnLoad]
public class StartupSceneLoader
{
    static StartupSceneLoader()
    {
        string scenePath = "Assets/WeaponVFX/Scenes/Scene_ErhanVFX.unity";

        if (EditorSceneManager.GetActiveScene().path != scenePath)
        {
            EditorSceneManager.OpenScene(scenePath);
        }
    }
}