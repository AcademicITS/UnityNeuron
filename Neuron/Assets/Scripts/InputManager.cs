using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class InputManager : MonoBehaviour
{
    private bool draggingItem = false;
    private GameObject draggedObject;
    private Vector2 touchOffset;

	public Text UIvoltage;
	public static float neuronVoltage = 0.0f;

	public GameObject posCharge;
	public GameObject negCharge;

	private float maxCharge = 3.0f;
	private float minCharge = -3.0f;

	void Start()
	{
		UIupdate();

		Color tmp = posCharge.GetComponent<SpriteRenderer> ().color;
		tmp.a = 0;
		posCharge.GetComponent<SpriteRenderer> ().material.color = tmp;
		negCharge.GetComponent<SpriteRenderer> ().material.color = tmp;
	}

    void Update()
    {
		if ((HasInput))
        {
			//Debug.Log ("Value: " + draggedObject.tag);
			//Debug.Log ("Input Received");
			DragOrPickUp();
			//function to calculate total neuron voltage and update UI
			UIupdate ();
			//function to change neuron color based on total voltage
			NeuronColor ();
        }
        else
        {
            if (draggingItem)
                DropItem();
        }
    }

    Vector2 CurrentTouchPosition
    {
        get
        {
            Vector2 inputPos;
            inputPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            return inputPos;
        }
    }

    private void DragOrPickUp()
    {
        var inputPosition = CurrentTouchPosition;

		if (draggingItem && !(draggedObject.CompareTag("Neuron")))
        {
			draggedObject.transform.position = inputPosition + touchOffset;
        }
        else
        {
            RaycastHit2D[] touches = Physics2D.RaycastAll(inputPosition, inputPosition, 0.5f);
            if (touches.Length > 0)
            {
                var hit = touches[0];
                if (hit.transform != null)
                {
                    draggingItem = true;
                    draggedObject = hit.transform.gameObject;
                    touchOffset = (Vector2)hit.transform.position - inputPosition;
                }
            }
        }
    }

    private bool HasInput
    {
        get
        {
            // returns true if either the mouse button is down or at least one touch is felt on the screen
            return Input.GetMouseButton(0);
        }
    }

    void DropItem()
    {
        draggingItem = false;
    }

	void UIupdate()
	{
		//Text to display on UI, with "F2" rounding to two decimal places
		UIvoltage.text = "Neuron: " + neuronVoltage.ToString ("F2") + " mV";
	}
		
	void NeuronColor()
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