using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    public Animator pacStudent;
    // Start is called before the first frame update
    void Start()
    {
        pacStudent.enabled = false;
        StartCoroutine(IdleAnim());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator IdleAnim()
    {
        yield return new WaitForSeconds(5);
        pacStudent.enabled = true;

    }
}
