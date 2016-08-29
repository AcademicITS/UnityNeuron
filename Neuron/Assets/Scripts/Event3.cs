using UnityEngine;
using System.Collections;

public class Event3 : MonoBehaviour {

<<<<<<< HEAD
	public GameObject NeuronBase;
    public GameObject Na;

    void OnTriggerEnter2D(Collider2D other)
    {
        //Check the provided Collider2D parameter other to see if it is tagged "Neuron", if it is...
        if (other.gameObject.CompareTag("Neuron"))
        {
			NeuronBase.GetComponent<SpriteRenderer>().material.color = Color.yellow;
            //Turns on Na's box collider which allows it to move//
            Na.GetComponent<Collider2D>().enabled = true;
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
            //Moves Na back to starting position//
            Na.transform.position = new Vector3 (-7.52f, -0.53f, 0f);
            //Turn off Na's collider to freeze it in place//
            Na.GetComponent<Collider2D>().enabled = false;
        }
    }
=======
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
>>>>>>> voltages
}
