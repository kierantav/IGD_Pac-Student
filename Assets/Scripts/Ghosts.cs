using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghosts : MonoBehaviour
{
    public SpriteRenderer ghostRenderer;
    // Start is called before the first frame update
    void Start()
    {
        ghostRenderer.enabled = false;
        StartCoroutine(LoadGhosts());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LoadGhosts() {
        yield return new WaitForSeconds(5);
        ghostRenderer.enabled = true;
    }
}
