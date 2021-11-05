using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
	public Animator crossfade;
	public Button level1Btn;
	public Text readyLbl;
	public AudioSource ghostNormal;

	// Start is called before the first frame update
	void Start()
	{
		if (SceneManager.GetActiveScene().buildIndex == 1)
		{
			StartCoroutine(PlayAudio());
		}

		Button btn = level1Btn.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	// Update is called once per frame
	void Update()
	{

	}

	void TaskOnClick()
	{
		StartCoroutine(LoadLevel(1));
	}

	IEnumerator LoadLevel(int buildIndex)
	{
		crossfade.SetTrigger("start");
		yield return new WaitForSeconds(1);
		SceneManager.LoadScene(buildIndex);
	}

	IEnumerator PlayAudio()
	{
		yield return new WaitForSeconds(5);
		ghostNormal.Play();
		readyLbl.enabled = false;
	}
}
