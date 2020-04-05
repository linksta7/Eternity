﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//for checking if players have a memory lense or not
public class CheckMemLense4 : MonoBehaviour
{

	public Text notifText;

	public string text1;
	public string text2;

	public GameObject textObj;
	public GameObject textbox;

	public GameObject closeNotifBtn;

	public GameObject lense;

	public string level;

	private Scene current;


	void Start()
	{
		current = SceneManager.GetActiveScene();
	}

	//check if players have a lense to unlock
	public void CheckLense()
	{
		if (MemoryLense.lense.obtainedStatus4 == 0)
		{
			notifText.text = text1;

			textObj.SetActive(true);
			textbox.SetActive(true);

			closeNotifBtn.SetActive(true);

		}

		else
		{
			notifText.text = text2;
			
			StartCoroutine(ShowAndHide(textObj, textbox));
			
			lense.SetActive(true);



			//open minigame
		}
	}
	IEnumerator ShowAndHide(GameObject text, GameObject textbox)
	{
		text.SetActive(true);
		textbox.SetActive(true);
		yield return new WaitForSeconds(0.5f);
		text.SetActive(false);
		textbox.SetActive(false);


		//SceneManager.LoadScene(level);
		//SceneManager.UnloadSceneAsync(current);


	}

	
}