using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActionRotationAround : Action
{
    Vector3 StartRotation_;

    Vector3 EndRotation_;

    float Angle_;


    public ActionRotationAround(GameObject objectM, Vector3 point, Vector3 axis, float angle, float duration = 0.0f, float time = 0.0f, EaseType type = 0, bool block_ = false, int blocknum_ = 0)
    {
        Actoor = objectM;
        StartRotation_ = point;

        EndRotation_ = axis;
        Angle_ = angle;
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

        Actoor.transform.RotateAround(StartRotation_, EndRotation_, Angle_ * (Time_/Duration_)); //rotation = Quaternion.Euler(0, Actoor.transform.localRotation.eulerAngles.y, (StartRotation_ + ((EndRotation_ - StartRotation_) * PercentageDone_)));

        if (PercentageDone_ >= 1.0)
            return false;


        return true;
    }

}
