using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class LevelGenerator : MonoBehaviour
{
    private static int levelWidth = 28;
    private static int levelHeight = 30;
    private int newY;

    public GameObject[,] level = new GameObject[levelWidth, levelHeight];

    // Start is called before the first frame update
    void Start()
    {
        List<GameObject> objects = GetObjects();


        foreach (GameObject obj in objects)
        {
            Vector2 pos = obj.transform.position;

            if (obj.tag == "pellet" || obj.tag == "powerPellet" || obj.tag == "wall")
            {
                //Debug.Log(pos.y);
                //Debug.Log(obj.tag + ": " + pos);
                //Debug.Log("(" + (int)pos.x + "," + (int)pos.y + 29 + ")");
                newY = 29 + (int)pos.y;
                //Debug.Log(newY);
                level[(int)pos.x, newY] = obj;
                //Debug.Log(level[(int)pos.x, newY] + ": (" + (int)pos.x + "," + newY + ")");
            }
            else if (obj.tag == "pacStudent")
            {
                //Debug.Log("Found Pac-Student at: " + pos);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    List<GameObject> GetObjects() {
        List<GameObject> objects = new List<GameObject>();

        foreach (GameObject obj in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[]) {
            if (!EditorUtility.IsPersistent(obj.transform.root.gameObject) && !(obj.hideFlags == HideFlags.NotEditable || obj.hideFlags == HideFlags.HideAndDontSave)) {
                objects.Add(obj);
            }
        }

        return objects;
    }
}
