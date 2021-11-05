using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostsController : MonoBehaviour
{
    public SpriteRenderer ghostRenderer;
    // Start is called before the first frame update
    void Start()
    {
        ghostRenderer.enabled = false;
        StartCoroutine(IdleAnim());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator IdleAnim()
    {
        yield return new WaitForSeconds(5);
        ghostRenderer.enabled = true;

    }
}
