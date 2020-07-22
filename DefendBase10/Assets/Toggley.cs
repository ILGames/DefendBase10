using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toggley : MonoBehaviour
{
	public GameObject switchOn, switchOff;
	int firstNumber = 0;

	void Start(){
		OnChangeValue();
	}
	void Update(){
		Debug.Log(firstNumber);
	}
	public void OnChangeValue() {
		bool onoffSwitch = gameObject.GetComponent<Toggle>().isOn;
		if (onoffSwitch)
		{
			switchOn.SetActive(true);
			switchOff.SetActive(false);
			firstNumber = 1;
		}
		if(!onoffSwitch)
		{
			switchOn.SetActive(false);
			switchOff.SetActive(true);
			firstNumber = 0;

		}
	}
}