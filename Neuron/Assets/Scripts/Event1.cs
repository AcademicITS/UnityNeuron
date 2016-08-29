using UnityEngine;
using System.Collections;

public class Event1 : MonoBehaviour {

	public GameObject NeuronBase;
	public ScriptMain ControlScript;

	private float voltage = 1.6f;

	void OnTriggerEnter2D(Collider2D other)
    {
        //Check the provided Collider2D parameter other to see if it is tagged "Neuron", if it is...
        if (other.gameObject.CompareTag("Neuron"))
        {
			//Increase total neuron voltage by variable when this transmitter collides
			ScriptMain.neuronVoltage = ScriptMain.neuronVoltage + voltage;

			//function to calculate total neuron voltage and update UI
			ControlScript.UIupdate ();
			//function to change neuron color based on total voltage
			ControlScript.NeuronColor ();
        }

    }

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Neuron"))
		{
			//Decrease total neuron voltage by variable when this transmitter exits
			ScriptMain.neuronVoltage = ScriptMain.neuronVoltage - voltage;

			//function to calculate total neuron voltage and update UI
			ControlScript.UIupdate ();
			//function to change neuron color based on total voltage
			ControlScript.NeuronColor ();
		}
	}
}
