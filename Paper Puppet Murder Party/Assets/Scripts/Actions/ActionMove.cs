using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMove : Action
{
    // Start is called before the first frame update



    Vector3 StartPosition_;

    Vector3 EndPosition_;

    float MoveSpeed_;

    public ActionMove(GameObject objectM, Vector3 start, Vector3 end, float duration = 0.0f, float time = 0.0f, EaseType type = 0, bool block_ = false, int blocknum_ = 0)
    {
        Actoor = objectM;
        StartPosition_ = start;
        EndPosition_ = end;
        Duration_ = duration;
        Time_ = time;
        easeType_ = type;
        
        block = block_;
        blocknum = blocknum_;
    }

    // Update is called once per frame
    override public bool Update()
    {
        Actoor.transform.localPosition = Vector3.Lerp(StartPosition_, EndPosition_, PercentageDone_);

        if (Actoor.transform.localPosition == EndPosition_ || PercentageDone_ >= 1.0f)
            return false;


        return true;

    }
}
