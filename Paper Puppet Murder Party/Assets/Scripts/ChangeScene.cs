using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    //edited ~10:30 pm friday by casey
    //simple placeholder script to switch a scene for main menu
    //takes a scene name, when run calls unity scene manager to load scene
    //can be swapped out if/when more robust scene management is added

    [SerializeField] private string sceneName;
    public void changeScene()
    {
        // Dis broken rn I gotta change it with async manager but it was bein freaky ~1am natalie
        SceneManager.LoadScene(sceneName);
    }
    
}
