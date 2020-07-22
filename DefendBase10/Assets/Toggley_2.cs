using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toggley_2 : MonoBehaviour
{
	public GameObject switchOn, switchOff;
	int secondNumber = 0;

	void Start(){
		OnChangeValue();
	}
	void Update(){
		Debug.Log(secondNumber);
	}
	public void OnChangeValue() {
		bool onoffSwitch = gameObject.GetComponent<Toggle>().isOn;
		if (onoffSwitch)
		{
			switchOn.SetActive(true);
			switchOff.SetActive(false);
			secondNumber = 2;
		}
		if(!onoffSwitch)
		{
			switchOn.SetActive(false);
			switchOff.SetActive(true);
			secondNumber = 0;

		}
	}
}
