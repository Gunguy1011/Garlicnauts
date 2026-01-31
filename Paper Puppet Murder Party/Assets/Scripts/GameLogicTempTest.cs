using UnityEngine;

public class GameLogicTempTest : MonoBehaviour
{
    private float timer = 3.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            AsyncSceneManager asyncSceneManager = GameManager.Instance.GetPersistentObject("AsyncSceneManager").GetComponent<AsyncSceneManager>();
            asyncSceneManager.SetEnabledScene("Scene3");
        }
    }
}
