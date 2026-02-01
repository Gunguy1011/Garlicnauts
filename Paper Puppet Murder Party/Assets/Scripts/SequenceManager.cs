using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SequenceManager : MonoBehaviour
{
    [Header("Test fjsjklfd")]
    public List<Action> actionSequence_ = new List<Action>();

    private ActionList actionList = new ActionList();

    private void Awake()
    {
        foreach (Action action in actionSequence_)
        {
            actionList.Actions.Add(action);
        }
    }

    private void Update()
    {
        if (actionList.Actions.Count > 0)
        {
            actionList.Update(Time.deltaTime);
        }
    }
}
