using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toggley_5 : MonoBehaviour
{
	public GameObject switchOn, switchOff;
	int fifthNumber = 0;

	void Start(){
		OnChangeValue();
	}
	void Update(){
		Debug.Log(fifthNumber);
	}
	public void OnChangeValue() {
		bool onoffSwitch = gameObject.GetComponent<Toggle>().isOn;
		if (onoffSwitch)
		{
			switchOn.SetActive(true);
			switchOff.SetActive(false);
			fifthNumber = 16;
		}
		if(!onoffSwitch)
		{
			switchOn.SetActive(false);
			switchOff.SetActive(true);
			fifthNumber = 0;

		}
	}
}
