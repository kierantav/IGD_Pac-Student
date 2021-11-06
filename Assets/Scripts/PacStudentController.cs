using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    public Animator pacStudent;
    public float speed = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        pacStudent.enabled = false;
        StartCoroutine(IdleAnim());
    }

    // Update is called once per frame
    void Update()
    {
        //CheckInput();
    }

    IEnumerator IdleAnim()
    {
        yield return new WaitForSeconds(5);
        pacStudent.enabled = true;

    }

    void CheckInput() {
        if (Input.GetKeyDown(KeyCode.W)) {
            Move(Vector2.up);
        } else if (Input.GetKeyDown(KeyCode.A)) {
            Move(Vector2.left);
        } else if (Input.GetKeyDown(KeyCode.S)) {
            Move(Vector2.down);
        } else if (Input.GetKeyDown(KeyCode.D)) {
            Move(Vector2.right);
        }
    }

    void Move(Vector2 direction) {
        transform.localPosition += (Vector3)(direction * speed) * Time.deltaTime;
    }
}
