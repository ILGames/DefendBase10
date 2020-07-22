using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toggley_4 : MonoBehaviour
{
	public GameObject switchOn, switchOff;
	int fourthNumber = 0;

	void Start(){
		OnChangeValue();
	}
	void Update(){
		Debug.Log(fourthNumber);
	}
	public void OnChangeValue() {
		bool onoffSwitch = gameObject.GetComponent<Toggle>().isOn;
		if (onoffSwitch)
		{
			switchOn.SetActive(true);
			switchOff.SetActive(false);
			fourthNumber = 8;
		}
		if(!onoffSwitch)
		{
			switchOn.SetActive(false);
			switchOff.SetActive(true);
			fourthNumber = 0;

		}
	}
}
