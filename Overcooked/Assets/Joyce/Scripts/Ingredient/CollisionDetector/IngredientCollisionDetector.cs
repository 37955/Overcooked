using UnityEngine;

public class IngredientCollisionDetector : MonoBehaviour
{
    private bool touchesPlayer;
    private bool touchesPan;
    private bool touchesChopCounter;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            touchesPlayer = true;
        }

        if (collision.collider.CompareTag("Pan"))
        {
            touchesPan = true;
        }

        if (collision.collider.CompareTag("ChopCounter"))
        {
            touchesChopCounter = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            touchesPlayer = false;
        }

        if (collision.collider.CompareTag("Pan"))
        {
            touchesPan = false;
        }

        if (collision.collider.CompareTag("ChopCounter"))
        {
            touchesChopCounter = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            touchesPlayer = true;
        }
        if (other.gameObject.CompareTag("ChopCounter"))
        {

            touchesChopCounter = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("no trigger player");
            touchesPlayer = false;
        }
        if (other.gameObject.CompareTag("ChopCounter"))
        {
            Debug.Log("no trigger chopcounter");
            touchesChopCounter = false;
        }
    }

    public bool TouchesPlayer
    {
        get { return touchesPlayer; }
    }

    public bool TouchesPan
    {
        get { return touchesPan; }
    }

    public bool TouchesChopCounter
    {
        get { return touchesChopCounter; }
    }

}
