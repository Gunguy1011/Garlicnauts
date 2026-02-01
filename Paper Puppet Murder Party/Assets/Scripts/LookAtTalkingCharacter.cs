using UnityEngine;

public class LookAtTalkingCharacter : MonoBehaviour
{
    GameObject[] characters;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       characters = GameObject.FindGameObjectsWithTag("Character");

    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject character in characters)
        {
            if (character.GetComponent<CharacterIsTalking>())
            {
                if (character.GetComponent<CharacterIsTalking>().isTalking_)
                transform.LookAt(new Vector3(character.transform.position.x, character.transform.position.y + 4.0f, character.transform.position.z));
            }
        }

    }
}
