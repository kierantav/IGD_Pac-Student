using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPelletFlash : MonoBehaviour
{
    public SpriteRenderer powerPelletRend;
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(Flash());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Flash() {
        yield return new WaitForSeconds(5);
        while (true) {
            powerPelletRend.enabled = false;
            yield return new WaitForSeconds(.25f);

            powerPelletRend.enabled = true;
            yield return new WaitForSeconds(.25f);
        }
    }
}
