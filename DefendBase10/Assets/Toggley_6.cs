using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toggley_6 : MonoBehaviour
{
	public GameObject switchOn, switchOff;
	int sixthNumber = 0;

	void Start(){
		OnChangeValue();
	}
	void Update(){
		Debug.Log(sixthNumber);
	}
	public void OnChangeValue() {
		bool onoffSwitch = gameObject.GetComponent<Toggle>().isOn;
		if (onoffSwitch)
		{
			switchOn.SetActive(true);
			switchOff.SetActive(false);
			sixthNumber = 32;
		}
		if(!onoffSwitch)
		{
			switchOn.SetActive(false);
			switchOff.SetActive(true);
			sixthNumber = 0;

		}
	}
}
