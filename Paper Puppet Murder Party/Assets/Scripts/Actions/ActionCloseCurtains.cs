using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionCloseCurtains : Action
{
    // Start is called before the first frame update
    private Vector3 rightCurtainStartPosition;
    private Vector3 rightCurtainEndPosition;
    private Vector3 leftCurtainStartPosition;
    private Vector3 leftCurtainEndPosition;
    private Vector3 topCurtainEndPosition;
    private Vector3 topCurtainStartPosition;
    public GameObject rightCurtain;
    public GameObject leftCurtain;
    public GameObject topCurtain;

    public ActionCloseCurtains(GameObject objectM, float duration = 0.0f, float time = 0.0f, EaseType type = 0, bool block_ = false, int blocknum_ = 0)
    {
        Actoor = objectM;
        Duration_ = duration;
        Time_ = time;
        easeType_ = type;
        
        block = block_;
        blocknum = blocknum_;
    }

    // Update is called once per frame
    override public bool Update()
    {
        // I'm too tired to figure out why this has to happen here 
        rightCurtainStartPosition = new Vector3(20f, 12.6f, -22.2f);
        rightCurtainEndPosition = new Vector3(13.30f, 12.6f, -22.2f);
        leftCurtainStartPosition = new Vector3(-5f, 12.6f, -22.2f);
        leftCurtainEndPosition = new Vector3(3.5f, 12.6f, -22.2f);
        topCurtainEndPosition = new Vector3(8.10f, 12.86f, -22.45f);
        topCurtainStartPosition = new Vector3(8.10f, 14.35f, -22.45f);

        rightCurtain.transform.localPosition = Vector3.Lerp(rightCurtainStartPosition, rightCurtainEndPosition, PercentageDone_);
        leftCurtain.transform.localPosition = Vector3.Lerp(leftCurtainStartPosition, leftCurtainEndPosition, PercentageDone_);
        topCurtain.transform.localPosition = Vector3.Lerp(topCurtainStartPosition, topCurtainEndPosition, PercentageDone_);

        if (rightCurtain.transform.localPosition == rightCurtainStartPosition || PercentageDone_ >= 1.0f)
            return false;


        return true;

    }
}
