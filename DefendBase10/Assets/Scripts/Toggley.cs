using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toggley : MonoBehaviour
{
	[SerializeField]
	public int digitNum = 0;
	public GameObject switchOn, switchOff;
	public int value = 0;

	void Start(){
		OnChangeValue();
	}
	void Update(){
		//Debug.Log(firstNumber);
	}
	public void OnChangeValue() {
		bool onoffSwitch = gameObject.GetComponent<Toggle>().isOn;
		if (onoffSwitch)
		{
			switchOn.SetActive(true);
			switchOff.SetActive(false);
			value = 1;
		}
		if(!onoffSwitch)
		{
			switchOn.SetActive(false);
			switchOff.SetActive(true);
			value = 0;

		}
	}
}
