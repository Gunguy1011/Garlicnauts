using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionTimer: Action
{
    // Start is called before the first frame update

    public ActionTimer(float duration, float time, EaseType type = 0, bool block_ = false, int blocknum_ = 0)
    {
      
       

        Duration_ = duration;
        Time_ = time;
        easeType_ = type;

        block = block_;
        blocknum = blocknum_;

   

    }

    // Update is called once per frame
    override public bool Update()
    {

        if (PercentageDone_ >= 1.0f)
        {
            return false;
        }

        return true;
    }
}
