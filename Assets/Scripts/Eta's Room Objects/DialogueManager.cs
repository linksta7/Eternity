﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{

	public Text dialogueText;

	public GameObject textboxObject;
	public GameObject dialogueObject;
	public GameObject nameObject;
	public GameObject continueButton;
	public GameObject headshot;

	public GameObject exitButton;

	private Queue<string> sentences;

	private GameObject clickedObj;

	// Use this for initialization
	void Start()
	{
		sentences = new Queue<string>();

	}

	public void StartDialogue(Dialogue dialogue)
	{
		//make textbox and dialogue appear onto screen
		continueButton.SetActive(true);
		nameObject.SetActive(true);
		dialogueObject.SetActive(true);
		textboxObject.SetActive(true);
		headshot.SetActive(true);

		clickedObj = EventSystem.current.currentSelectedGameObject;

		sentences.Clear();

		//iterates through queue that is holding the dialogue sentences(?)
		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
		return;

	}

	public void DisplayNextSentence()
	{
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();
		StopAllCoroutines(); //immediately stops letters from appearing one by one
		StartCoroutine(TypeSentence(sentence)); //trigger letters to start appearing one by one
		return;
	}

	IEnumerator TypeSentence(string sentence)
	{
		//make letters in dialogue appear one by one
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}

	void EndDialogue()
	{


		if (clickedObj.tag == "Puzzle")
		{
			//make textbox and dialogue disappear when finished
			continueButton.SetActive(false);
			textboxObject.SetActive(false);
			nameObject.SetActive(false);
			dialogueObject.SetActive(false);
			headshot.SetActive(false);

			exitButton.SetActive(true);
		}

		else
		{
			//make textbox and dialogue disappear when finished
			continueButton.SetActive(false);
			textboxObject.SetActive(false);
			nameObject.SetActive(false);
			dialogueObject.SetActive(false);
			headshot.SetActive(false);

			clickedObj.GetComponent<ShowTrigger>().ShowObjs();
		}

	}

}