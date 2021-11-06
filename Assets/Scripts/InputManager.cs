using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    [SerializeField] private GameObject pacStudent;
    private Tweener tweener;
    private string lastInput;
    private string currentInput;
    private LevelGenerator levelGenerator;
    public GameObject levelLoader;
    private float timer;
    public AudioSource hitWallAudio;
    public Text scoreLbl;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        levelGenerator = levelLoader.GetComponent<LevelGenerator>();
        tweener = GetComponent<Tweener>();
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 4) {
            scoreLbl.text = score.ToString();
            Vector2 pos = pacStudent.transform.position;
            pos.y += 29;

            if (Input.GetKeyDown("a") || lastInput == "a")
            {
                lastInput = "a";
                if (isWalkable(lastInput, pos))
                {
                    tweener.AddTween(pacStudent.transform, pacStudent.transform.position, new Vector3(pacStudent.transform.position.x - 1.0f, pacStudent.transform.position.y, 0.0f), 0.25f);
                }
            }
            if (Input.GetKeyDown("d") || lastInput == "d")
            {
                lastInput = "d";

                if (isWalkable(lastInput, pos))
                {
                    tweener.AddTween(pacStudent.transform, pacStudent.transform.position, new Vector3(pacStudent.transform.position.x + 1.0f, pacStudent.transform.position.y, 0.0f), 0.25f);
                }
            }
            if (Input.GetKeyDown("s") || lastInput == "s")
            {
                lastInput = "s";
                if (isWalkable(lastInput, pos))
                {
                    tweener.AddTween(pacStudent.transform, pacStudent.transform.position, new Vector3(pacStudent.transform.position.x, pacStudent.transform.position.y - 1.0f, 0.0f), 0.25f);
                }
            }
            if (Input.GetKeyDown("w") || lastInput == "w")
            {
                lastInput = "w";
                if (isWalkable(lastInput, pos))
                {
                    tweener.AddTween(pacStudent.transform, pacStudent.transform.position, new Vector3(pacStudent.transform.position.x, pacStudent.transform.position.y + 1.0f, 0.0f), 0.25f);
                }
            }
        }

    }

    public bool isWalkable(string lastInput, Vector2 pos) {
        for (int i = 0; i < 28; ++i)
        {
            for (int j = 0; j < 30; ++j)
            {
                if (levelGenerator.level[i, j] != null)
                {
                    if (lastInput == "d" && levelGenerator.level[i, j].tag == "wall" && i == 1 + (int)pos.x && j == (int)pos.y)
                    {
                        lastInput = "";
                        hitWallAudio.Play();
                        return false;
                    }
                    else if (lastInput == "a" && levelGenerator.level[i, j].tag == "wall" && i == (int)pos.x - 1 && j == (int)pos.y)
                    {
                        lastInput = "";
                        hitWallAudio.Play();
                        return false;
                    }
                    else if (lastInput == "s" && levelGenerator.level[i, j].tag == "wall" && i == (int)pos.x && j == (int)pos.y - 1)
                    {
                        lastInput = "";
                        hitWallAudio.Play();
                        return false;
                    }
                    else if (lastInput == "w" && levelGenerator.level[i, j].tag == "wall" && i == (int)pos.x && j == 1 + (int)pos.y)
                    {
                        lastInput = "";
                        hitWallAudio.Play();
                        return false;
                    }
                    else if (lastInput == "d" && levelGenerator.level[i, j].tag == "pellet" && i == 1 + (int)pos.x && j == (int)pos.y) {
                        levelGenerator.level[i, j].SetActive(false);
                        score += 10;
                    }
                    else if (lastInput == "a" && levelGenerator.level[i, j].tag == "pellet" && i == (int)pos.x - 1 && j == (int)pos.y)
                    {
                        levelGenerator.level[i, j].SetActive(false);
                        score += 10;
                    }
                    else if (lastInput == "s" && levelGenerator.level[i, j].tag == "pellet" && i == (int)pos.x && j == (int)pos.y - 1)
                    {
                        levelGenerator.level[i, j].SetActive(false);
                        score += 10;
                    }
                    else if (lastInput == "w" && levelGenerator.level[i, j].tag == "pellet" && i == (int)pos.x && j == 1 + (int)pos.y)
                    {
                        levelGenerator.level[i, j].SetActive(false);
                        score += 10;
                    }


                }

            }
        }
        currentInput = lastInput;
        return true;
    }
}
