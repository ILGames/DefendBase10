using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonAppear : MonoBehaviour{

	public Toggle toggle1, toggle2, toggle3, toggle4, toggle5, toggle6;
	public int levelPassed;
	GameObject Button_2;
	GameObject Button_3;
	GameObject Button_4;
	GameObject Button_5;
	GameObject Button_6;

	void Start() 
	{

        Button_2 = GameObject.Find("Button_2");
	toggle2.interactable = false;
        Button_3 = GameObject.Find("Button_3");
	toggle3.interactable = true;
        Button_4 = GameObject.Find("Button_4");
	toggle4.interactable = true;
        Button_5 = GameObject.Find("Button_5");
	toggle5.interactable = true;
        Button_6 = GameObject.Find("Button_6");
	toggle6.interactable = true;

        levelPassed = PlayerPrefs.GetInt ("LevelPassed");
		Button_2.GetComponent<Renderer>().enabled = false;
		Button_3.GetComponent<Renderer>().enabled = false;
		Button_4.GetComponent<Renderer>().enabled = false;
		Button_5.GetComponent<Renderer>().enabled = false;
		Button_6.GetComponent<Renderer>().enabled = false;		


	switch (levelPassed) 
		{
		case 1:
			toggle2.interactable = true;
			Button_2.GetComponent<Renderer>().enabled = true;
			break;
		case 2:
			toggle2.interactable = true;
			Button_2.GetComponent<Renderer>().enabled = true;
			toggle3.interactable = true;
			Button_3.GetComponent<Renderer>().enabled = true;
			break;
		case 3:
			toggle2.interactable = true;
			Button_2.GetComponent<Renderer>().enabled = true;
			toggle3.interactable = true;
			Button_3.GetComponent<Renderer>().enabled = true;
			toggle4.interactable = true;
			Button_4.GetComponent<Renderer>().enabled = true;
			break;
		case 4:
			toggle2.interactable = true;
			Button_2.GetComponent<Renderer>().enabled = true;
			toggle3.interactable = true;
			Button_3.GetComponent<Renderer>().enabled = true;
			toggle4.interactable = true;
			Button_4.GetComponent<Renderer>().enabled = true;
			toggle5.interactable = true;
			Button_5.GetComponent<Renderer>().enabled = true;
			break;
		case 5:
			toggle2.interactable = true;
			Button_2.GetComponent<Renderer>().enabled = true;
			toggle3.interactable = true;
			Button_3.GetComponent<Renderer>().enabled = true;
			toggle4.interactable = true;
			Button_4.GetComponent<Renderer>().enabled = true;
			toggle5.interactable = true;
			Button_5.GetComponent<Renderer>().enabled = true;
			toggle6.interactable = true;
			Button_6.GetComponent<Renderer>().enabled = true;
			break;
		}
	}
	public void resetPlayerPrefs()
	{
		toggle2.interactable = false;
		Button_2.GetComponent<Renderer>().enabled = false;
		toggle3.interactable = false;
		Button_3.GetComponent<Renderer>().enabled = false;
		toggle4.interactable = false;
		Button_4.GetComponent<Renderer>().enabled = false;
		toggle5.interactable = false;
		Button_5.GetComponent<Renderer>().enabled = false;
		toggle6.interactable = false;
		Button_6.GetComponent<Renderer>().enabled = false;
		PlayerPrefs.DeleteAll ();
	}
}