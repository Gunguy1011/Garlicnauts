using UnityEngine;
public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    [Header("Persistent Objects")]
    public GameObject[] persistentObjects;

    public static GameManager Instance
    {
        get { return _instance; }
    }

    // Singleton Pattern
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
            MarkPersistentObjects();
        }
    }

    // Mark 
    private void MarkPersistentObjects()
    {
        foreach(GameObject obj in persistentObjects)
        {
            if (obj != null)
            {
                DontDestroyOnLoad(obj);
            }
        }
    }

    private void DestroyAllPersistentObjects()
    {
        foreach(GameObject obj in persistentObjects)
        {
            Destroy(obj);
        }
        Destroy(gameObject);
    }
}
