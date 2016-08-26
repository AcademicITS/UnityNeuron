using UnityEngine;
using System.Collections;

public class Event3 : MonoBehaviour {

	public GameObject NeuronBase;
	public ScriptMain ControlScript;

	private float voltage = -1.8f;

    void OnTriggerEnter2D(Collider2D other)
    {
        //Check the provided Collider2D parameter other to see if it is tagged "Neuron", if it is...
        if (other.gameObject.CompareTag("Neuron"))
        {
			//NeuronBase.GetComponent<SpriteRenderer>().material.color = Color.yellow;
			//see equivalent code in Event1.cs
			ScriptMain.neuronVoltage = ScriptMain.neuronVoltage + voltage;

			//function to calculate total neuron voltage and update UI
			ControlScript.UIupdate ();
			//function to change neuron color based on total voltage
			ControlScript.NeuronColor ();
        }
	}

	void OnTriggerExit2D(Collider2D other)
	{
		{
			//see equivalent code in Event1.cs
			ScriptMain.neuronVoltage = ScriptMain.neuronVoltage - voltage;

			//function to calculate total neuron voltage and update UI
			ControlScript.UIupdate ();
			//function to change neuron color based on total voltage
			ControlScript.NeuronColor ();
		}
	}
}
