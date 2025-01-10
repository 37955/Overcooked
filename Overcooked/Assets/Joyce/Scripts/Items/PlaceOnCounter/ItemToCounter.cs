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
        if (rb == null)
        {
            Debug.Log("rb is niet gevonden :p");
        }
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
            Debug.Log("raakt counter aan");
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
            Debug.Log("uit de counter coll");
            canPlace = false;
            resetRB();
        }
    }

    void moveToCounterPlace()
    {
        transform.position = ingredientPlacesCounter.transform.position;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        Debug.Log("Is naar de counter gegaan");
    }

    void resetRB()
    {
        rb.constraints = RigidbodyConstraints.None;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }
}

