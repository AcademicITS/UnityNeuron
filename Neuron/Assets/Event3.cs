using UnityEngine;
using System.Collections;

public class Event3 : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        //Check the provided Collider2D parameter other to see if it is tagged "Neuron", if it is...
        if (other.gameObject.CompareTag("Neuron"))
        {
            other.gameObject.transform.GetComponent<Renderer>().material.color = Color.yellow;
        }
    }
}
