using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class AsyncSceneManager : MonoBehaviour
{
    [Header("All Scenes In Game")]
    public string[] scenes;

    private List<AsyncScene> asyncScenes_;

    void Awake()
    {
        Debug.Log("Bro");
        foreach (string sceneName in scenes)
        {
            asyncScenes_.Add(new AsyncScene(scene));
        }
    }

    public void LoadScene(string sceneName)
    {
        // If scene exists in the scene manager, load it
        foreach (AsyncScene asyncscene in asyncScenes_)
        {
            if (asyncscene.scene_.name.Equals(sceneName))
            {
                SceneManager.LoadSceneAsync(sceneName);
                asyncscene.SetLoaded(true);
            }
        }
    }

    public void UnloadScene(string sceneName)
    {
        // If scene exists in the scene manager, unload it
        foreach (AsyncScene asyncscene in asyncScenes_)
        {
            if (asyncscene.scene_.name.Equals(sceneName))
            {
                SceneManager.UnloadSceneAsync(sceneName);
                asyncscene.SetLoaded(false);
            }
        }
    }

    public void ActivateScene(string sceneName)
    {
        // If scene exists in the scene manager, activate it
        foreach (AsyncScene asyncscene in asyncScenes_)
        {
            if (asyncscene.scene_.name.Equals(sceneName))
            {
                ActivateScene(asyncscene);
            }
        }
    }

    public void DeactivateScene(string sceneName)
    {
        // If scene exists in the scene manager, deactivate it
        foreach (AsyncScene asyncscene in asyncScenes_)
        {
            if (asyncscene.scene_.name.Equals(sceneName))
            {
                DeactivateScene(asyncscene);
            }
        }
    }

    // Set all of the game objects in a scene to active
    private void ActivateScene(AsyncScene scene)
    {
        if (scene.isLoaded_)
        {
            GameObject[] objs = scene.scene_.GetRootGameObjects();
            foreach (GameObject obj in objs)
            {
                obj.SetActive(true);
            }
            scene.isActive_ = true;
        }
        else
        {
            Debug.LogError("Tried to activate scene '" + scene.scene_.name + ",' but the scene is not loaded.");
        }
    }

    // Set all of the game objects in a scene to inactive
    private void DeactivateScene(AsyncScene scene)
    {
        if (scene.isLoaded_)
        {
            GameObject[] objs = scene.scene_.GetRootGameObjects();
            foreach (GameObject obj in objs)
            {
                obj.SetActive(false);
            }
            scene.isActive_ = false;
        }
        else
        {
            Debug.LogError("Tried to deactivate scene '" + scene.scene_.name + ",' but the scene is not loaded.");
        }
    }
}

public struct AsyncScene
{
    public Scene scene_;
    public bool isActive_;
    public bool isLoaded_;

    public AsyncScene(Scene scene)
    {
        scene_ = scene;
        isActive_ = false;
        isLoaded_ = false;
    }

    public void SetLoaded(bool loaded)
    {
        isLoaded_ = loaded;
    }
}
