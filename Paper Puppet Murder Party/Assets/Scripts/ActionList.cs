using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Action;

public class ActionList
{

    public List<Action> Actions;
    public bool paused = false;
    public bool blocked = false;


    // Start is called before the first frame update
    public ActionList()
    {
        Actions = new List<Action>();
    }

    // Update is called once per frame
    public void Update(float dt)
    {

        if (paused == true)
            dt = 0.0f;

        int blocknu = 0;
        // float dt = Time.deltaTime;
        for (int i = 0; i < Actions.Count; i++)
        {

            if (blocked)
            {
                if (Actions[i].block == true)
                {
                    if (Actions[i].blocknum != blocknu)
                    {
                            blocknu = Actions[i].blocknum;
                    }
                    else
                        continue;
                }
                
            }

            if (Actions[i].IncrementTime(dt) == false)
                continue;
            if (Actions[i].Update() == false)
            {
                Actions.RemoveAt(i);
                i--;
                continue;
            }
            //if (Actions[i].)

        }

    }


    public void Spawn(GameObject objectM, GameObject pref, Vector3 adjustment = default(Vector3),float duration = 0.0f, float time = 0.0f, EaseType type = 0, bool block_ = false, int blocknum_ = 0)
    {
        Actions.Add(new ActionSpawn(objectM, pref, adjustment, duration, time, type, block_, blocknum_));
    }


    public void Mover(GameObject objectM, Vector3 start, Vector3 end, float duration = 0.0f, float time = 0.0f, Action.EaseType type = 0, bool block = false, int num = 0)
    {
        Actions.Add(new ActionMove(objectM, start, end, duration, time, type, block, num));
    }

    public void Mover(GameObject objectM, Vector3 end, float duration = 0.0f, float time = 0.0f, Action.EaseType type = 0, bool block = false, int num = 0)
    {
        // Actions.Add(new ActionTranslate(objectM, objectM.transform.localPosition, end, duration, time));
        Actions.Add(new ActionMove(objectM, objectM.transform.localPosition, end, duration, time, type, block, num));
    }

    public void MoveText(GameObject objectM, Vector3 start, Vector3 end, float duration = 0.0f, float time = 0.0f, Action.EaseType type = 0, bool block = false, int num = 0)
    {
        Actions.Add(new ActionMoveText(objectM, start, end, duration, time, type, block, num));
    }

    public void MoveText(GameObject objectM, Vector3 end, float duration = 0.0f, float time = 0.0f, Action.EaseType type = 0, bool block = false, int num = 0)
    {
        // Actions.Add(new ActionTranslate(objectM, objectM.transform.localPosition, end, duration, time));
        Actions.Add(new ActionMoveText(objectM, objectM.transform.localPosition, end, duration, time, type, block, num));
    }

    public void RotateAround(GameObject objectM, Vector3 point, Vector3 axis, float angle, float duration = 0.0f, float time = 0.0f, EaseType type = 0, bool block_ = false, int blocknum_ = 0)
    {
        Actions.Add(new ActionRotationAround(objectM, point, axis, angle, duration, time, type, block_, blocknum_));
    }
    public void RotateAround(GameObject objectM, GameObject object2, Vector3 axis, float angle, float duration = 0.0f, float time = 0.0f, EaseType type = 0, bool block_ = false, int blocknum_ = 0)
    {
        Actions.Add(new ActionRotationAround(objectM, object2.transform.localPosition, axis, angle, duration, time, type, block_, blocknum_));
    }

    public void Scale(GameObject objectM, Vector3 start, Vector3 end, float duration = 0.0f, float time = 0.0f, EaseType type = 0, bool block = false, int num = 0)
    {
        Actions.Add(new ActionScale(objectM, start, end, duration, time, type, block, num));
    }

    public void Scale(GameObject objectM, float scale, float duration = 0.0f, float time = 0.0f, EaseType type = 0, bool block = false, int num = 0)
    {
        Actions.Add(new ActionScale(objectM, objectM.transform.localScale, objectM.transform.localScale * scale, duration, time, type, block, num));
    }
    public void Rotate(GameObject objectM, Vector3 start, Vector3 end, float duration = 0.0f, float time = 0.0f, Action.EaseType type = 0, bool block = false, int num = 0)
    {
        // Actions.Add(new ActionTranslate(objectM, objectM.transform.localPosition, end, duration, time));
        Actions.Add(new ActionRotation(objectM, start, end, duration, time, type, block, num));
    }


    public void Rotate(GameObject objectM, Vector3 end, float duration = 0.0f, float time = 0.0f, Action.EaseType type = 0, bool block = false, int num = 0)
    {
        // Actions.Add(new ActionTranslate(objectM, objectM.transform.localPosition, end, duration, time));
        Actions.Add(new ActionRotation(objectM, new Vector3(objectM.transform.localRotation.x, objectM.transform.localRotation.y, objectM.transform.localRotation.z), end, duration, time, type, block, num));
    }

    public void Destroy(GameObject objectM, float duration = 0.0f, float time = 0.0f, EaseType type = 0, bool block_ = false, int blocknum_ = 0)
    {
        Actions.Add(new ActionDestroy(objectM, duration, time, type, block_, blocknum_));
    }


    public void Fade(GameObject objectM, float start, float end, float duration = 0.0f, float time = 0.0f, Action.EaseType type = 0, bool block = false, int num = 0)
    {
        Actions.Add(new ActionFade(objectM, start, end, duration, time, type, block, num));
    }
    public void Fade(GameObject objectM, float end, float duration = 0.0f, float time = 0.0f, Action.EaseType type = 0, bool block = false, int num = 0)
    {
        Actions.Add(new ActionFade(objectM, objectM.GetComponent<Renderer>().material.color.a, end, duration, time, type, block, num));
    }

    public void FadeText(GameObject objectM, float start, float end, float duration = 0.0f, float time = 0.0f, Action.EaseType type = 0, bool block = false, int num = 0)
    {
        Actions.Add(new ActionFadeText(objectM, start, end, duration, time, type, block, num));
    }
    public void FadeText(GameObject objectM, float end, float duration = 0.0f, float time = 0.0f, Action.EaseType type = 0, bool block = false, int num = 0)
    {
        Actions.Add(new ActionFadeText(objectM, objectM.GetComponent<TextMeshPro>().alpha, end, duration, time, type, block, num));
    }

    public void ChangeText(GameObject objectM, string change, float duration = 0.0f, float time = 0.0f, Action.EaseType type = 0, bool block = false, int num = 0)
    {
        Actions.Add(new ActionChangeText(objectM, change, duration, time, type, block, num));
    }

    public void ScreenShake(Camera cam, float tense, float duration = 0.0f, float time = 0.0f, EaseType type = 0, bool block = false, int num = 0)
    {
        {
           // Actions.Add(new ActionScreenShake(cam, tense, duration, time, type, block, num));
        }
    }

    public void ChangeColor(GameObject objectM, Color start, Color end, float duration = 0.0f, float time = 0.0f, EaseType type = 0, bool block_ = false, int blocknum_ = 0)
    {
        Actions.Add(new ActionChangeColor(objectM, start, end, duration, time, type, block_, blocknum_));
    }

    public void ChangeColor(GameObject objectM, Color end, float duration = 0.0f, float time = 0.0f, EaseType type = 0, bool block_ = false, int blocknum_ = 0)
    {
        Actions.Add(new ActionChangeColor(objectM, objectM.GetComponent<Renderer>().material.color, end, duration, time, type, block_, blocknum_));
    }


    public void ChangeColorAll(MeshRenderer[] _objects, List<Color> start, List<Color> end, float duration = 0.0f, float time = 0.0f, EaseType type = 0, bool block_ = false, int blocknum_ = 0)
    {
        Actions.Add(new ActionChangeColorAll(_objects, start, end, duration, time, type, block_, blocknum_));
    }

    public void ChangeColorAll(MeshRenderer[] _objects, List<Color> start, Color end, float duration = 0.0f, float time = 0.0f, EaseType type = 0, bool block_ = false, int blocknum_ = 0)
    {
        List<Color> colors = new List<Color>();

        for(int i = 0; i < _objects.Length;i++)
        {
            colors.Add(end);
        }

        Actions.Add(new ActionChangeColorAll(_objects, start, colors, duration, time, type, block_, blocknum_));
    }

    public void ChangeColorAll(MeshRenderer[] _objects, Color start, List<Color> end, float duration = 0.0f, float time = 0.0f, EaseType type = 0, bool block_ = false, int blocknum_ = 0)
    {
        List<Color> colors = new List<Color>();

        for (int i = 0; i < _objects.Length; i++)
        {
            colors.Add(start);
        }

        Actions.Add(new ActionChangeColorAll(_objects, colors, end, duration, time, type, block_, blocknum_));
    }


    public void Timer(float duration, float time, EaseType type = 0, bool block_ = false, int blocknum_ = 0)
    {
        Actions.Add(new ActionTimer(duration, time, type, block_, blocknum_));
    }

    public void EnableScene(GameObject objectM, string sceneToEnable, float duration = 0.0f, float time = 0.0f, EaseType type = 0, bool block_ = false, int blocknum_ = 0)
    {
        Actions.Add(new ActionEnableScene(objectM, sceneToEnable, duration, time, type, block_, blocknum_));
    }

}

