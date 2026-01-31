using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActionSpawn : Action
{
    
    GameObject make;
    Vector3 position;
    Vector3 Adjustment_;
    Quaternion rotation;
//
    public ActionSpawn(GameObject objectM, GameObject pref, Vector3 adjustment = default(Vector3), float duration = 0.0f, float time = 0.0f, EaseType type = 0, bool block_ = false, int blocknum_ = 0)
    {
        Actoor = objectM;
        position = objectM.transform.position;
        rotation = Quaternion.Euler(Actoor.transform.rotation.eulerAngles);
        Adjustment_ = adjustment;


        make = pref;
      
        Duration_ = duration;
        Time_ = time;
        easeType_ = type;

        block = block_;
        blocknum = blocknum_;
    }


    // Update is called once per frame
    override public bool Update()
    {

        if (Actoor != null)
        {
            GameObject trail = GameObject.Instantiate(make);
            trail.transform.position = Actoor.transform.position;
            trail.transform.rotation = Quaternion.Euler(Actoor.transform.rotation.eulerAngles + Adjustment_);
        }
        else
        {
            GameObject trail = GameObject.Instantiate(make, position, rotation);
        }


        return false;
    }

}
