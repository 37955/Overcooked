using UnityEngine;

public class PickUp : MonoBehaviour
{
    private GameObject ingredient;
    private Rigidbody ingredientRigidbody;

    void Start()
    {
        ingredient = null;
        ingredientRigidbody = null;
    }

    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ingredient" && ingredient == null)
        {
            ingredient = collision.gameObject;
            ingredientRigidbody = ingredient.GetComponent<Rigidbody>();

            Debug.Log("lalalalal");
            if (ingredientRigidbody != null)
            {
                ingredientRigidbody.isKinematic = true;
            }
            ingredient.transform.position = transform.position;
            ingredient.transform.SetParent(transform, true);
            ingredient.SetActive(false);
        }
    }
}
