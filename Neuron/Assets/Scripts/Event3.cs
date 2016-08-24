using UnityEngine;
using System.Collections;

public class Event3 : MonoBehaviour {

	public GameObject NeuronBase;
    public GameObject Na;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        //Check the provided Collider2D parameter other to see if it is tagged "Neuron", if it is...
        if (other.gameObject.CompareTag("Neuron"))
        {
			NeuronBase.GetComponent<SpriteRenderer>().material.color = Color.yellow;
            //Clone Na within the Neuron body//
            Instantiate(Na, new Vector3 (-0.49f, .76f, .2754617f), Quaternion.Euler (0,0,0));
            }
	}

	void OnTriggerExit2D(Collider2D other)
	{
		{
            NeuronBase.GetComponent<SpriteRenderer>().material.color = Color.white;
            //This removes the Na clone created above//
            Destroy(GameObject.Find("Na(Clone)"));
		}
	}
}
