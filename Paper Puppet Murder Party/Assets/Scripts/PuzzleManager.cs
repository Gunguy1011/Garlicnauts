using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private Transform gameTransform;
    [SerializeField] private Transform piecePrefab;
    [SerializeField] public List<Action> piecePrefab2;
    //[SerializeField] private GameObject win;
    [SerializeField] public int size = 3;
    [SerializeField] public bool randomSpace = true;
    [SerializeField] public GameObject box;

    public GameObject dagger;
    public GameObject poison;

    private List<Transform> pieces;
    private int emptyLocation;

    public ActionList Aclist = new();

    private bool won = false;

    private bool debug = false;

    private void CreateGamePieces(float gapThickness)
    {
        //size of tile
        float width = 1 / (float)size;

        //if we want a random space, this will set it, otherwise will be bottom left corner
        int emptyx = size - 1;
        int emptyy = size - 1;
        if (randomSpace)
        {
            emptyx = Random.Range(0, size - 1);
            emptyy = Random.Range(0, size - 1);
        }
        emptyLocation = (emptyx * size ) + emptyy;
        for (int row = 0; row < size; ++row)
        {
            for (int col = 0; col < size; ++col)
            {
                Transform piece = Instantiate(piecePrefab, gameTransform);
                pieces.Add(piece);
                piece.localPosition = new Vector3(-1 + (2 * width * col) + width,
                                                  +1 - (2 * width * row) - width,
                                                  0);
                piece.localScale = ((2 * width) - gapThickness) * Vector3.one;
                piece.name = $"{(row * size) + col}";


                //split UVs
                float gap = gapThickness / 2.0f;

                Mesh mesh = piece.GetComponent<MeshFilter>().mesh;

                //UV order: (0,1), (1,1), (0,0), (1,0)
                Vector2[] uv = new Vector2[4];

                uv[0] = new Vector2((width * col) + gap, 1 - ((width * (row + 1)) - gap));
                uv[1] = new Vector2((width * (col + 1)) - gap, 1 - ((width * (row + 1)) - gap));
                uv[2] = new Vector2((width * col) + gap, 1 - ((width * row) + gap));
                uv[3] = new Vector2((width * (col + 1)) - gap, 1 - ((width * row) + gap));

                mesh.uv = uv;


                //make sure there is a missing spot
                if((row == emptyx) &&  (col == emptyy))
                {
                    //emptyLocation = (size * size) - 1;
                    piece.gameObject.SetActive(false);
                }
            }
        }
    }






    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

        switch (size)
        {
            case 2:
                piecePrefab = poison.transform;
                break;
            default:
                piecePrefab = dagger.transform;
                break;
            

                break;
        }

        pieces = new List<Transform>();
       // size = 2;
        CreateGamePieces(0.01f);
        Shuffle();
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Aclist.Actions.Count > 0)
        {
            Aclist.Update(Time.deltaTime);
        }

        // Cheat code key
        if (Input.GetKeyDown(KeyCode.Space) && debug)
        {
            Aclist.blocked = true;
            Aclist.FadeMesh(pieces[emptyLocation].gameObject, 0, 1, 1, 0, Action.EaseType.None, true, 1);
            Aclist.EnableScene(null, "MainGame", 0, 0, Action.EaseType.None, true, 1);

            pieces[emptyLocation].GetComponent<MeshRenderer>().material.color = new Color(pieces[emptyLocation].GetComponent<MeshRenderer>().material.color.r, pieces[emptyLocation].GetComponent<MeshRenderer>().material.color.g, pieces[emptyLocation].GetComponent<MeshRenderer>().material.color.b, 0);
            pieces[emptyLocation].gameObject.SetActive(true);
            won = true;
        }

        if (Input.GetMouseButtonDown(0) && !won)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit)
            {
                for(int i = 0; i < pieces.Count; ++i)
                {
                    if (pieces[i] == hit.transform)
                    {
                        if (SwapIfValid(i, -size, size)) { break; }
                        if (SwapIfValid(i, +size, size)) { break; }
                        if (SwapIfValid(i, -1, 0)) { break; }
                        if (SwapIfValid(i, +1, size - 1)) { break; }

                    }
                }

                if(CheckCompletion())
                {
                    Aclist.blocked = true;

                    Aclist.FadeMesh(pieces[emptyLocation].gameObject, 0, 1, 1, 0, Action.EaseType.None, true, 1);
                    Aclist.EnableScene(null, "MainGame", 0, 0, Action.EaseType.None, true, 1);

                    pieces[emptyLocation].GetComponent<MeshRenderer>().material.color = new Color(pieces[emptyLocation].GetComponent<MeshRenderer>().material.color.r, pieces[emptyLocation].GetComponent<MeshRenderer>().material.color.g, pieces[emptyLocation].GetComponent<MeshRenderer>().material.color.b, 0);
                    pieces[emptyLocation].gameObject.SetActive(true);
                    won = true;

                }



            }
        }
    }

    private bool SwapIfValid(int i, int offset, int colCheck)
    {
        if(((i % size) != colCheck) && ((i + offset) == emptyLocation))
        {

            (pieces[i], pieces[i + offset]) = (pieces[i + offset], pieces[i]);

            (pieces[i].localPosition, pieces[i + offset].localPosition) = ((pieces[i + offset].localPosition, pieces[i].localPosition));

            emptyLocation = i;

            //sound here


            return true;
        }
        return false;
    }

    private void Shuffle()
    {
        int count = 0;
        int last = 0;

        while (count < (size * size * size))
       //while(count < 1)
        {
            int rnd = Random.Range(0, size * size);

            if (rnd == last)
            {
                count--;
                continue;
            }
            last = emptyLocation;
            if (SwapIfValid(rnd, -size, size)) { ++count; }
            else if (SwapIfValid(rnd, +size, size)) { ++count; }
            else if (SwapIfValid(rnd, -1, 0)) { ++count; }
            else if (SwapIfValid(rnd, +1, size - 1)) { ++count; }

        }

        if(CheckCompletion())
        {
            Shuffle();
        }

    }


    private bool CheckCompletion()
    {

        for(int i = 0; i < pieces.Count; ++i)
        {
            if (pieces[i].name != $"{i}")
            {
                return false;
            }
        }

        //WIN
        return true;
    }

}
