using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionActivate : Action
{
    // Start is called before the first frame update



    public ActionActivate(GameObject objectM, float duration = 0.0f, float time = 0.0f, EaseType type = 0, bool block_ = false, int blocknum_ = 0)
    {
        Actoor = objectM;
     
        Duration_ = duration;
        Time_ = time;
        easeType_ = type;

        block = block_;
        blocknum = blocknum_;
    }

    // Update is called once per frame
    override public bool Update()
    {
        
        Actoor.SetActive(true);

        return false;

        


    }
}
