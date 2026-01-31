using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ActionChangeText : Action
{
    // Start is called before the first frame update


    string change;

   

  
    public ActionChangeText(GameObject objectM, string change_, float duration = 0.0f, float time = 0.0f, EaseType type = 0, bool block_ = false, int blocknum_ = 0)
    {
        Actoor = objectM;


        change = change_;

        Duration_ = duration;
        Time_ = time;
        easeType_ = type;

        block = block_;
        blocknum = blocknum_;

     
   

    }

    // Update is called once per frame
    override public bool Update()
    {


        Actoor.GetComponent<TextMeshProUGUI>().text = change;


        return false;
    }
}
