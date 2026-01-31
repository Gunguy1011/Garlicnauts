using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ActionFadeText : Action
{
    float StartFade_;

    float EndFade_;

    float MoveSpeed_;



    public ActionFadeText(GameObject objectM, float start, float end, float duration = 0.0f, float time = 0.0f, EaseType type = 0, bool block_ = false, int blocknum_ = 0)
    {
        Actoor = objectM;
        StartFade_ = start;
        EndFade_ = end;
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

        //float e = Actoor.GetComponent<MeshRenderer>();

        //e = (StartFade_ + ((EndFade_ - StartFade_) * PercentageDone_));

        float newalpha = StartFade_ + (EndFade_ - StartFade_) * PercentageDone_;
        Mathf.Clamp01(newalpha);

        Actoor.GetComponent<TextMeshPro>().alpha = newalpha;

        if (PercentageDone_ >= 1.0)
            return false;



        return true;
    }

}
