using UnityEngine;
using System.Collections;

public class Event1 : MonoBehaviour {

	public GameObject NeuronBase;

	void OnTriggerEnter2D(Collider2D other)
    {
        //Check the provided Collider2D parameter other to see if it is tagged "Neuron", if it is...
        if (other.gameObject.CompareTag("Neuron"))
        {
			//NeuronBase.GetComponent<SpriteRenderer>().material.color = Color.red;
			//Increase total neuron voltage by 1.6 when this transmitter collides
			InputManager.neuronVoltage = InputManager.neuronVoltage + 1.6f;

        }

    }

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Neuron"))
		{
			//NeuronBase.GetComponent<SpriteRenderer>().material.color = Color.white;
			//Decrease total neuron voltage by 1.6 when this transmitter exits
			InputManager.neuronVoltage = InputManager.neuronVoltage - 1.6f;
		}
	}
}
