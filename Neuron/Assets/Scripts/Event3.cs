using UnityEngine;
using System.Collections;

public class Event3 : MonoBehaviour {

	public GameObject NeuronBase;

    void OnTriggerEnter2D(Collider2D other)
    {
        //Check the provided Collider2D parameter other to see if it is tagged "Neuron", if it is...
        if (other.gameObject.CompareTag("Neuron"))
        {
			NeuronBase.GetComponent<SpriteRenderer>().material.color = Color.yellow;
        }
	}

	void OnTriggerExit2D(Collider2D other)
	{
		{
			NeuronBase.GetComponent<SpriteRenderer>().material.color = Color.white;
		}
	}
}
