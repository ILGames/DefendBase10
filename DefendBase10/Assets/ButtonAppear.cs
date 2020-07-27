using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonAppear : MonoBehaviour{

	public Toggle toggle1, toggle2, toggle3, toggle4, toggle5, toggle6;
	public int levelPassed;
	void start() 
	{
		levelPassed = PlayerPrefs.GetInt ("LevelPassed");
		toggle2.interactable = false;


	switch (levelPassed) 
		{
		case 1:
			toggle2.interactable = true;

			break;
		case 2:
			toggle2.interactable = true;

			toggle3.interactable = true;

			break;
		case 3:
			toggle2.interactable = true;

			toggle3.interactable = true;

			toggle4.interactable = true;

			break;
		case 4:
			toggle2.interactable = true;

			toggle3.interactable = true;

			toggle4.interactable = true;

			toggle5.interactable = true;

			break;
		case 5:
			toggle2.interactable = true;

			toggle3.interactable = true;

			toggle4.interactable = true;

			toggle5.interactable = true;

			toggle6.interactable = true;

			break;
		}
	}
	public void resetPlayerPrefs()
	{
		toggle2.interactable = false;

		toggle3.interactable = false;

		toggle4.interactable = false;

		toggle5.interactable = false;	

		toggle6.interactable = false;
	
		PlayerPrefs.DeleteAll ();
	}
}