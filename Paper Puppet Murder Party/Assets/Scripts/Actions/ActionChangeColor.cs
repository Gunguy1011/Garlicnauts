using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ActionChangeColor : Action
{
    Color StartFade_;

    Color EndFade_;

    float MoveSpeed_;



    public ActionChangeColor(GameObject objectM, Color start, Color end, float duration = 0.0f, float time = 0.0f, EaseType type = 0, bool block_ = false, int blocknum_ = 0)
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

        Color newalpha = StartFade_ + (EndFade_ - StartFade_) * PercentageDone_;

        Actoor.GetComponent<Renderer>().material.color = newalpha;

       

        //Actoor.GetComponent<Renderer>().material.color = new Color(Actoor.GetComponent<Renderer>().material.color.r, Actoor.GetComponent<Renderer>().material.color.g, Actoor.GetComponent<Renderer>().material.color.b, newalpha);

        if (PercentageDone_ >= 1.0)
            return false;


        return true;
    }

}
