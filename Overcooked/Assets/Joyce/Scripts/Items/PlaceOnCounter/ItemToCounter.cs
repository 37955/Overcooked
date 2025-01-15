using Unity.VisualScripting;
using UnityEngine;

public class ItemToCounter : MonoBehaviour
{
    private GameObject ingredientPlacesCounter;
    private Rigidbody rb;
    private bool canPlace;
    private float pickupRange = 2f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (canPlace)
        {
            if (Input.GetKey(KeyCode.Space))
            {
               moveToCounterPlace();
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("PlaceCounter"))
        {
            ThereisAnCollision();
        }

        void ThereisAnCollision()
        {
            ingredientPlacesCounter = collision.collider.transform.Find("IngredientPlace").gameObject;
            canPlace = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("PlaceCounter"))
        {
            OutOfCollider();
        }
        void OutOfCollider()
        {
            canPlace = false;
            resetRB();
        }
    }

    void moveToCounterPlace()
    {
        transform.position = ingredientPlacesCounter.transform.position;
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    void resetRB()
    {
        rb.constraints = RigidbodyConstraints.None;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }
}

