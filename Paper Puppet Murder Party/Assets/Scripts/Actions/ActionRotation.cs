using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActionRotation : Action
{
    Vector3 StartRotation_;

    Vector3 EndRotation_;

    float MoveSpeed_;


    public ActionRotation(GameObject objectM, Vector3 start, Vector3 end, float duration = 0.0f, float time = 0.0f, EaseType type = 0, bool block_ = false, int blocknum_ = 0)
    {
        Actoor = objectM;
        StartRotation_ = start;
        EndRotation_ = end;
        Duration_ = duration;
        Time_ = time;
        easeType_ = type;

        block = block_;
        blocknum = blocknum_;
    }


    // Update is called once per frame
    override public bool Update()
    {
        //Actoor.transform.Rotate(Vector3.Lerp(StartRotation_, EndRotation_, PercentageDone_));
        //Actoor.transform.localRotation.Euler(Vector3.Lerp(StartRotation_, EndRotation_, PercentageDone_));

        Actoor.transform.localRotation = Quaternion.Euler((StartRotation_.x + ((EndRotation_.x - StartRotation_.x) * PercentageDone_)), (StartRotation_.y + ((EndRotation_.y - StartRotation_.y) * PercentageDone_)), (StartRotation_.z + ((EndRotation_.z - StartRotation_.z) * PercentageDone_)));

        if (PercentageDone_ >= 1.0)
            return false;


        return true;
    }

}
