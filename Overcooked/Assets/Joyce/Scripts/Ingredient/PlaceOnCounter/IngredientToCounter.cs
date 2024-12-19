using Unity.VisualScripting;
using UnityEngine;

public class IngredientToCounter : MonoBehaviour
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
               
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Counter"))
        {
            ingredientPlacesCounter = collision.collider.transform.Find("IngredientPlace").gameObject;
            Debug.Log("raakt counter aan");
            canPlace = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Counter"))
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
    }

    void resetRB()
    {
        rb.constraints = RigidbodyConstraints.None;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }
}

