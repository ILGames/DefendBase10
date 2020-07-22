using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toggley_3 : MonoBehaviour
{
	public GameObject switchOn, switchOff;
	int thirdNumber = 0;

	void Start(){
		OnChangeValue();
	}
	void Update(){
		Debug.Log(thirdNumber);
	}
	public void OnChangeValue() {
		bool onoffSwitch = gameObject.GetComponent<Toggle>().isOn;
		if (onoffSwitch)
		{
			switchOn.SetActive(true);
			switchOff.SetActive(false);
			thirdNumber = 4;
		}
		if(!onoffSwitch)
		{
			switchOn.SetActive(false);
			switchOff.SetActive(true);
			thirdNumber = 0;

		}
	}
}
