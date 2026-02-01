using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using FMODUnity;
using UnityEngine.UI;


public class DialogueBox : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public FMODEventPlayable[] FMODEventsiHopeThisIsRight;

   

    [SerializeField]
    public Sprite Georgia;//0

    [SerializeField]
    public Sprite Narrator; //1

    [SerializeField]
    public Sprite Femme; //2

    [SerializeField]
    public Sprite Redd; //3

    [SerializeField]
    public Sprite Al; //4

    [SerializeField]
    public Sprite Everyone; //5

    [SerializeField]
    public int sprit = -1;

    private int index;

    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();

        switch (sprit)
        {
            case 0:
            gameObject.GetComponent<Image>().sprite = Georgia;
                break;
            case 1:
                gameObject.GetComponent<Image>().sprite = Narrator;
                break;
            case 2:
                gameObject.GetComponent<Image>().sprite = Femme;
                break;
            case 3:
                gameObject.GetComponent<Image>().sprite = Redd;
                break;
            case 4:
                gameObject.GetComponent<Image>().sprite = Al;
                break;
                case 5:
                gameObject.GetComponent<Image>().sprite = Everyone;
                break;
            default:
                break;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            //play typewriter sound
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            //finished talking
            gameObject.SetActive(false);
        }
    }

}