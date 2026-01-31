using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionScale : Action
{
    // Start is called before the first frame update



    public Vector3 StartPosition_;
    public Vector3 EndPosition_;

    float MoveSpeed_;

    public ActionScale(GameObject objectM, Vector3 start, Vector3 end, float duration = 0.0f, float time = 0.0f, EaseType type = 0, bool block_ = false, int blocknum_ = 0)
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
        Vector3 scl = Actoor.transform.localScale;
        scl = StartPosition_ + (EndPosition_ - StartPosition_) * PercentageDone_;

        //scl = (start[obj] + (end - start[obj]) * PercentageDone_);
        Actoor.transform.localScale = scl;

        if (Actoor.transform.localScale == EndPosition_ || PercentageDone_ >= 1.0f)
            return false;


        return true;

    }
}
