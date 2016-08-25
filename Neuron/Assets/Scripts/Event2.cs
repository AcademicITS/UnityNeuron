using UnityEngine;
using System.Collections;

public class Event2 : MonoBehaviour {

	public GameObject NeuronBase;

    void OnTriggerEnter2D(Collider2D other)
    {
        //Check the provided Collider2D parameter other to see if it is tagged "Neuron", if it is...
        if (other.gameObject.CompareTag("Neuron"))
        {
			//NeuronBase.GetComponent<SpriteRenderer>().material.color = Color.blue;
			//see equivalent code in Event1.cs
			InputManager.neuronVoltage = InputManager.neuronVoltage - 1.2f;
        }
	}

	void OnTriggerExit2D(Collider2D other)
	{
		{
			//NeuronBase.GetComponent<SpriteRenderer>().material.color = Color.white;
			//see equivalent code in Event1.cs
			InputManager.neuronVoltage = InputManager.neuronVoltage + 1.2f;
		}
	}
}
