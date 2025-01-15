using UnityEngine;

public class IngredientCollisionDetector : MonoBehaviour
{
    private bool touchesPlayer;
    private bool touchesPan;
    private bool touchesCounter;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Is touching the player");
            touchesPlayer = true;
        }

        if (collision.collider.CompareTag("Pan"))
        {
            Debug.Log("Is touching the Pan");
            touchesPan = true;
        }

        if (collision.collider.CompareTag("ChopCounter"))
        {
            Debug.Log("Is touching the Counter");
            touchesCounter = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Is NOT touching the player");
            touchesPlayer = false;
        }

        if (collision.collider.CompareTag("Pan"))
        {
            Debug.Log("Is NOT touching the Pan");
            touchesPan = false;
        }

        if (collision.collider.CompareTag("ChopCounter"))
        {
            Debug.Log("Is NOT touching the counter");
            touchesCounter = false;
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

    public bool TouchesCounter
    {
        get { return touchesCounter; }
    }
}
