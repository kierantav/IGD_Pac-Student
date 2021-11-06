using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
	public Animator crossfade;
	public Button level1Btn;
	public Button exitBtn;
	public Text readyLbl;
	public AudioSource ghostNormal;

	// Start is called before the first frame update
	void Start()
	{
		if (SceneManager.GetActiveScene().buildIndex == 1)
		{
			StartCoroutine(PlayAudio());
		}

		Button level1 = level1Btn.GetComponent<Button>();
		level1.onClick.AddListener(TaskOnClick);

		Button exit = exitBtn.GetComponent<Button>();
		exit.onClick.AddListener(TaskOnClick);
	}

	// Update is called once per frame
	void Update()
	{

	}

	void TaskOnClick()
	{
		if (SceneManager.GetActiveScene().buildIndex == 0)
		{
			StartCoroutine(LoadLevel(1));
		}
		else {
			StartCoroutine(LoadLevel(0));
		}
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
