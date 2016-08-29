using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScriptMain : MonoBehaviour {

	public Text UIvoltage;
	public static float neuronVoltage = 0.0f;

	public GameObject posCharge;
	public GameObject negCharge;

	private float maxCharge = 3.0f;
	private float minCharge = -3.0f;

	// Use this for initialization
	void Start () {
		
		UIupdate();

		Color tmp = posCharge.GetComponent<SpriteRenderer> ().color;
		tmp.a = 0;
		posCharge.GetComponent<SpriteRenderer> ().material.color = tmp;
		negCharge.GetComponent<SpriteRenderer> ().material.color = tmp;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UIupdate()
	{
		//Text to display on UI, with "F2" rounding to two decimal places
		UIvoltage.text = "Neuron: " + neuronVoltage.ToString ("F2") + " mV";
	}

	public void NeuronColor()
	// Assigns alpha value to red & blue layers based on neuron charge
	{
		Color tmpPos = posCharge.GetComponent<SpriteRenderer> ().color;
		//determine percentage of the maximum voltage neuron is currently at
		tmpPos.a = neuronVoltage / maxCharge;
		if (tmpPos.a <= 0.0f) {
			tmpPos.a = 0.0f;
		}
		//set material alpha (transparency) based on percentage calculated above
		posCharge.GetComponent<SpriteRenderer> ().material.color = tmpPos;
		//Debug.LogError (tmp.a);

		Color tmpNeg = negCharge.GetComponent<SpriteRenderer> ().color;
		//determine percentage of the minimum voltage neuron is currently at
		tmpNeg.a = neuronVoltage / minCharge;
		if (tmpNeg.a <= 0.0f) {
			tmpNeg.a = 0.0f;
		}
		//set material alpha (transparency) based on percentage calculated above
		negCharge.GetComponent<SpriteRenderer> ().material.color = tmpNeg;

	}
}
