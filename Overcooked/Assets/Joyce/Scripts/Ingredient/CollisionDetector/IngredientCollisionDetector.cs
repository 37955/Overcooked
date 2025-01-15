using UnityEngine;

public class IngredientCollisionDetector : MonoBehaviour
{
    private bool touchesPlayer;
    private bool touchesPan;
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
    }

    public bool TouchPlayer
    {
        get { return touchesPlayer; }
    }

    public bool TouchesPan
    {
        get { return touchesPan; }
    }
}
