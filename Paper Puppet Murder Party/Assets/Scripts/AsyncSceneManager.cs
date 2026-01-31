using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class AsyncSceneManager : MonoBehaviour
{
    [Header("All Scenes In Game")]
    public string[] sceneNames_;

    private List<AsyncScene> asyncScenes_ = new List<AsyncScene>();
    int currentLoadedScene = 0;
    private List<AsyncOperation> asyncOperations_ = new List<AsyncOperation>();
    private List<string> loadingScenes_ = new List<string>();

    private int currentSceneLoading;

    void Awake()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        AsyncScene currentAsyncScene = new AsyncScene(currentScene);
        currentAsyncScene.SetEnabled(true);
        asyncScenes_.Add(currentAsyncScene);

        foreach (string sceneName in sceneNames_)
        {
            if (!currentScene.name.Equals(sceneName))
            {
                loadingScenes_.Add(sceneName);
                asyncOperations_.Add(SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive));
                asyncOperations_[asyncOperations_.Count - 1].allowSceneActivation = false;
            }
        }
    }

    // Set all of the game objects in a scene to active
    public void SetEnabledScene(string sceneName)
    {
        // If the scene matches, activate it and set to active
        foreach (AsyncScene ourScene in asyncScenes_)
        {
            if (ourScene.scene_.name.Equals(sceneName))
            {
                ourScene.SetEnabled(true);
                SceneManager.SetActiveScene(ourScene.scene_);
            }
            // If it is not our scene, set active to false
            else
            {
                ourScene.SetEnabled(false);
            }
        }
    }

    public bool IsSceneEnabled(string sceneName)
    {
        foreach (AsyncScene ourScene in asyncScenes_)
        {
            if (ourScene.scene_.name.Equals(sceneName))
            {
                return ourScene.isEnabled_;
            }
        }
        Debug.LogError("You requested " + sceneName + " but it is not included in the AsyncSceneManager!");
        return false;
    }

    private void Update()
    {
        List<int> toRemove = new List<int>();
        for (int i = 0; i < asyncOperations_.Count; i++)
        {
            if (!asyncOperations_[i].isDone)
            {
                Debug.Log("Loading scene " + sceneNames_[i]);
            }
            else
            {
                AsyncScene newScene = new AsyncScene(SceneManager.GetSceneByName(loadingScenes_[i]));
                asyncScenes_.Add(newScene);
                newScene.SetEnabled(false);
                
                toRemove.Add(i);
            }
        }
        // ts lowkey fucked but whatever
        for (int j = toRemove.Count - 1; j >= 0; j--)
        {
            asyncOperations_.RemoveAt(toRemove[j]);
            loadingScenes_.RemoveAt(toRemove[j]);
        }
    }
}

public struct AsyncScene
{
    public Scene scene_;
    public bool isEnabled_;

    public AsyncScene(Scene scene)
    {
        scene_ = scene;
        isEnabled_ = false;
    }

    public void SetEnabled(bool isEnabled) 
    { 
        isEnabled_ = isEnabled; 
        if (isEnabled_) // if enabled = true, set all objects in scene to active
        {
            GameObject[] objs = this.scene_.GetRootGameObjects();
            foreach (GameObject obj in objs)
            {
                obj.SetActive(true);
            }
        }
        else // if enabled = false, set all objects in scene to inactive
        {
            GameObject[] objs = this.scene_.GetRootGameObjects();
            foreach (GameObject obj in objs)
            {
                obj.SetActive(false);
            }
        }
    }
}
