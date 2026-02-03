using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMove : Action
{
    // Start is called before the first frame update



    public Vector3 StartPosition_;

    public Vector3 EndPosition_;

    public Transform StartPositionTransform_;
    public Transform EndPositionTransform_;

    public float MoveSpeed_;

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

        if (StartPositionTransform_ && EndPositionTransform_)
        {
            StartPosition_ = StartPositionTransform_.position;
            EndPosition_ = EndPositionTransform_.position;
        }

        Actoor.transform.localPosition = Vector3.Lerp(StartPosition_, EndPosition_, PercentageDone_);

        if (Actoor.transform.localPosition == EndPosition_ || PercentageDone_ >= 1.0f)
        {
            PercentageDone_ = Time_ = 0;
            return false;
        }


        return true;

    }

    private void OnDisable()
    {
    }
}
