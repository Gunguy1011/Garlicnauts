using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using FMODUnity;
using static UnityEditor.Profiling.RawFrameDataView;

public class ActionFMODEvent : Action
{
    public FMODUnity.EventReference[] FMODEvents;
    public ActionFMODEvent(GameObject objectM, float duration = 0.0f, float time = 0.0f, EaseType type = 0, bool block_ = false, int blocknum_ = 0)
    {
        Actoor = objectM;
        Duration_ = duration;
        Time_ = time;
        easeType_ = type;

        block = block_;
        blocknum = blocknum_;

    }

    private void Start()
    {
    }

    // Update is called once per frame
    override public bool Update()
    {
        foreach (FMODUnity.EventReference e in FMODEvents)
        {
            FMODUnity.RuntimeManager.PlayOneShot(e);
        }
        return false;
    }

}
