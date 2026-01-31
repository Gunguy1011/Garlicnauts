using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
abstract public class Action
{
    public float Time_;
    public float Duration_;
    public float PercentageDone_;
    public float EntityID_;
    public bool block = false;
    public int blocknum = 0;



    public enum EaseType
    {
        None = 0,
        EaseIn, EaseOut, EaseInOut,
        FastIn, FastOut, FastInOut,
        EaseInFastOut, FastInEaseOut

    }

    public EaseType easeType_;

    public GameObject Actoor = null;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    abstract public bool Update();





    public bool IncrementTime(float dt)
    {
        Time_ += dt;
        if (Time_ < 0.0f)
            return false;

        if (Time_ >= Duration_)
        {
            Time_ = Duration_;
            PercentageDone_ = 1.0f;
        }
        else
        {
            PercentageDone_ = Time_ / Duration_;
        }

        PercentageDone_ = Ease(PercentageDone_, easeType_);

        return true;
    }

    public float TimeLeft()
    {
        return Duration_ - Time_;
    }

    public float Ease(float percent, EaseType type)
    {
        switch (type)
        {
            case EaseType.None:
                {
                    break;
                }
            case EaseType.EaseIn:
                {
                    percent = MathF.Sqrt(percent);
                    break;
                }
            case EaseType.EaseOut:
                {
                    percent = percent * percent;
                    break;
                }
            case EaseType.EaseInOut:
                {
                    if (percent < .5f)
                    {
                        percent = (MathF.Pow((2.0f * percent), 2.0f)) / 2.0f;
                    }
                    else
                    {
                        percent = ((MathF.Sqrt(((percent - .5f) * 2.0f))) / 2.0f) + .5f;
                    }

                    break;
                }
            case EaseType.FastIn:
                {
                    percent = MathF.Sqrt(MathF.Sqrt(percent));
                    break;
                }
            case EaseType.FastOut:
                {
                    percent = percent * percent * percent * percent;
                    break;
                }
            case EaseType.FastInOut:
                {
                    break;
                }

        }


        return percent;

    }
}
