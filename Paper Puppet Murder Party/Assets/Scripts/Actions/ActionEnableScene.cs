using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ActionEnableScene : Action
{

    string sceneToEnable_;


    public ActionEnableScene(GameObject objectM, string sceneToEnable, float duration = 0.0f, float time = 0.0f, EaseType type = 0, bool block_ = false, int blocknum_ = 0)
    {
        Actoor = objectM;
        sceneToEnable_ = sceneToEnable;
        Duration_ = duration;
        Time_ = time;
        easeType_ = type;

        block = block_;
        blocknum = blocknum_;

    }


    // Update is called once per frame
    override public bool Update()
    {
        AsyncSceneManager asyncSceneManager = GameManager.Instance.GetPersistentObject("AsyncSceneManager").GetComponent<AsyncSceneManager>();
        asyncSceneManager.SetEnabledScene(sceneToEnable_);

        return false;
    }

}
